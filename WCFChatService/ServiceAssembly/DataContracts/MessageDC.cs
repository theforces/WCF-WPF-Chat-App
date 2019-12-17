using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ServiceAssembly.DataContracts
{
    [DataContract]
    public class MessageDC
    {
        private string _sender;
        private string _content;
        private DateTime _time;

        [DataMember]
        public string Sender
        {
            get { return _sender; }
            set { _sender = value; }
        }
        [DataMember]
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
        [DataMember]
        public DateTime Time
        {
            get { return _time; }
            set { _time = value; }
        }
    }
}
