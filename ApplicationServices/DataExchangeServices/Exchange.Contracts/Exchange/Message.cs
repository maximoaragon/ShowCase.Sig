using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Exchange.Contracts
{
    [DataContract]
    [KnownType(typeof(EventMessage))]
    [KnownType(typeof(StatusMessage))]
    [KnownType(typeof(CommandMessage))]
    [KnownType(typeof(ExchangeMessage))]
    public class Message 
    {
        [DataMember]
        public Guid RequestID {get;set;}
        [DataMember]
        public string RequestName {get;set;}

    }
}
