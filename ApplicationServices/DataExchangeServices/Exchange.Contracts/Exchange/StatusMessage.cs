using System.Runtime.Serialization;

namespace Exchange.Contracts
{
    [DataContract]
    public class StatusMessage : Message
    {
        [DataMember]
        public ProcessState Status { get; set; }
        [DataMember]
        public object Data { get; set; }
    }
}