using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Com.Wiseape.Gateway.Email.Data.Model;

namespace Com.Wiseape.Gateway.Email.View.Form
{
    [DataContract]
    public class SendEmailForm
    {
        [DataMember]
        public string To { get; set; }

        [DataMember]
        public string Cc { get; set;  }

        [DataMember]
        public string Bcc { get; set; }

        [DataMember]
        public string Tag { get; set; }

        [DataMember]    
        public List<KeyValue> KeyValues;

        [DataMember]
        public List<EmailAttachment> Attachments;

    }

    public class KeyValue
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
