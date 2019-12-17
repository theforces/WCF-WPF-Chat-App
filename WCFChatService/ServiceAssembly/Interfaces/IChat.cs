using ServiceAssembly.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace ServiceAssembly.Interfaces
{
    [ServiceContract(CallbackContract = typeof(IChatCallback), SessionMode = SessionMode.Required)]
    public interface IChat
    {
        [OperationContract(IsInitiating = true)]
        bool Connect(ClientDC client);

        [OperationContract(IsOneWay = false)]
        bool Register(ClientDC client);

        [OperationContract(IsOneWay = false)]
        bool Update(ClientDC client, string password);

        [OperationContract(IsOneWay = false)]
        bool Delete(ClientDC client);

        [OperationContract(IsOneWay = true)]
        void Say(MessageDC msg);

        [OperationContract(IsOneWay = true)]
        void Whisper(MessageDC msg, ClientDC receiver);

        [OperationContract(IsOneWay = true)]
        void IsWriting(ClientDC client);

        [OperationContract(IsOneWay = false)]
        bool SendFile(FileMessageDC fileMsg, ClientDC receiver);

        [OperationContract(IsOneWay = true, IsTerminating = true)]
        void Disconnect(ClientDC client);
    }
}
