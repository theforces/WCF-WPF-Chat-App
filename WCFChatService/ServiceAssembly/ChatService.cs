using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Runtime.Serialization;
using ServiceAssembly.Interfaces;
using ServiceAssembly.DataContracts;

namespace ServiceAssembly
{

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
    ConcurrencyMode = ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
    public class ChatService : IChat
    {
        Dictionary<ClientDC, IChatCallback> clients = new Dictionary<ClientDC, IChatCallback>();

        List<ClientDC> clientList = new List<ClientDC>();

        public IChatCallback CurrentCallback
        {
            get
            {
                return OperationContext.Current.GetCallbackChannel<IChatCallback>();

            }
        }

        object syncObj = new object();

        private bool SearchClientsByName(string name)
        {
            foreach (ClientDC c in clients.Keys)
            {
                if (c.Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        private void RemoveClientsByNameFromClientsDictionary(string name)
        {
            bool found = true;
            ClientDC client = null; ;
            while (found)
            {
                found = false;
                foreach (ClientDC c in clients.Keys)
                {
                    if (c.Name == name)
                    {
                        client = c;
                        found = true;
                        break;
                    }
                }
                if (client != null)
                {
                    IChatCallback localCalback;
                    var ok = clients.TryGetValue(client, out localCalback);
                    localCalback.DisconnectClient(client);
                    clients.Remove(client);
                }
            }


        }
        private void RemoveClientsByNameFromClientsList(string name)
        {
            bool found = true;
            ClientDC client = null; ;
            while (found)
            {
                found = false;
                foreach (ClientDC c in clientList)
                {
                    if (c.Name == name)
                    {
                        client = c;
                        found = true;
                        break;
                    }
                }
                if (client != null)
                    clientList.Remove(client);
            }


        }
        #region IChat Members

        public bool Connect(ClientDC client)
        {
            if (!SQL_DB.Validate(client.Name, client.Password))
            {
                return false;
            }


            if (!clients.ContainsValue(CurrentCallback) && !SearchClientsByName(client.Name))
            {
                lock (syncObj)
                {
                    clients.Add(client, CurrentCallback);
                    clientList.Add(client);

                    foreach (ClientDC key in clients.Keys)
                    {
                        IChatCallback callback = clients[key];
                        try
                        {
                            callback.RefreshClients(clientList);
                            callback.UserJoin(client);
                        }
                        catch
                        {
                            clients.Remove(key);
                            return false;
                        }

                    }

                }
                return true;
            }
            RemoveClientsByNameFromClientsDictionary(client.Name);
            RemoveClientsByNameFromClientsList(client.Name);
            foreach (IChatCallback callback in clients.Values)
            {

                callback.RefreshClients(this.clientList);
                callback.UserLeave(client);
            }


            return false;
        }

        public bool Register(ClientDC client)
        {
            bool found = SQL_DB.Validate(client.Name, client.Password);
            if (found == true)
            {
                //exista deja nu am ce adauga
                //todo de trimis notificare prin callback pentru a anunta clientul de utilizator deja existent
                return false;
            }
            else
            {
                return SQL_DB.Register(client.Name, client.Password);
                
            }
        }

        public bool Delete(ClientDC client)
        {
            return SQL_DB.Delete(client.Name);
        }

        public bool Update(ClientDC client, string password)
        {
            return SQL_DB.Update(client.Name, password);

        }
        public void Say(MessageDC msg)
        {
            lock (syncObj)
            {
                foreach (IChatCallback callback in clients.Values)
                {
                    callback.Receive(msg);
                }
            }
        }

        public void Whisper(MessageDC msg, ClientDC receiver)
        {
            foreach (ClientDC rec in clients.Keys)
            {
                if (rec.Name == receiver.Name)
                {
                    IChatCallback callback = clients[rec];
                    callback.ReceiveWhisper(msg, rec);

                    foreach (ClientDC sender in clients.Keys)
                    {
                        if (sender.Name == msg.Sender)
                        {
                            IChatCallback senderCallback = clients[sender];
                            senderCallback.ReceiveWhisper(msg, rec);
                            return;
                        }
                    }
                }
            }
        }


        public bool SendFile(FileMessageDC fileMsg, ClientDC receiver)
        {
            foreach (ClientDC rcvr in clients.Keys)
            {
                if (rcvr.Name == receiver.Name)
                {
                    MessageDC msg = new MessageDC();
                    msg.Sender = fileMsg.Sender;
                    msg.Content = "I'M SENDING FILE.. " + fileMsg.FileName;

                    IChatCallback rcvrCallback = clients[rcvr];
                    rcvrCallback.ReceiveWhisper(msg, receiver);
                    rcvrCallback.ReceiverFile(fileMsg, receiver);

                    foreach (ClientDC sender in clients.Keys)
                    {
                        if (sender.Name == fileMsg.Sender)
                        {
                            IChatCallback sndrCallback = clients[sender];
                            sndrCallback.ReceiveWhisper(msg, receiver);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public void IsWriting(ClientDC client)
        {
            lock (syncObj)
            {
                foreach (IChatCallback callback in clients.Values)
                {
                    callback.IsWritingCallback(client);
                }
            }
        }

        public void Disconnect(ClientDC client)
        {
            foreach (ClientDC c in clients.Keys)
            {
                if (client.Name == c.Name)
                {
                    lock (syncObj)
                    {
                        this.clients.Remove(c);
                        this.clientList.Remove(c);
                        foreach (IChatCallback callback in clients.Values)
                        {
                            callback.RefreshClients(this.clientList);
                            callback.UserLeave(client);
                        }
                    }
                    return;
                }
            }
        }

        #endregion
    }
}
