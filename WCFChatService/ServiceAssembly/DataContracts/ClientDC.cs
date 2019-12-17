using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ServiceAssembly.DataContracts
{
    [DataContract]
    public class ClientDC
    {
        private string _name;
        private int _avatarID;
        private DateTime _time;

        [DataMember]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public int AvatarID
        {
            get { return _avatarID; }
            set { _avatarID = value; }
        }
        [DataMember]
        public DateTime Time
        {
            get { return _time; }
            set { _time = value; }
        }
    }
}
