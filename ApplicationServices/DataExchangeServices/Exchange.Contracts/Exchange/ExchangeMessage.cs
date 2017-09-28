using System.Runtime.Serialization;

namespace Exchange.Contracts
{
    [DataContract]
    public class ExchangeMessage : Message
    {
        [DataMember]
        public string ExchangeName { get; set; }
        [DataMember]
        public string ExchangeData { get; set; }
    }
}
