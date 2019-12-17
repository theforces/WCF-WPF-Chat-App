using ServiceAssembly.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace ServiceAssembly.Interfaces
{

    public interface IChatCallback
    {
        [OperationContract(IsOneWay = true)]
        void RefreshClients(List<ClientDC> clients);

        [OperationContract(IsOneWay = true)]
        void Receive(MessageDC msg);

        [OperationContract(IsOneWay = true)]
        void ReceiveWhisper(MessageDC msg, ClientDC receiver);

        [OperationContract(IsOneWay = true)]
        void IsWritingCallback(ClientDC client);

        [OperationContract(IsOneWay = true)]
        void ReceiverFile(FileMessageDC fileMsg, ClientDC receiver);

        [OperationContract(IsOneWay = true)]
        void UserJoin(ClientDC client);

        [OperationContract(IsOneWay = true)]
        void UserLeave(ClientDC client);

        [OperationContract(IsOneWay = true)]
        void DisconnectClient(ClientDC client);


    }

}
