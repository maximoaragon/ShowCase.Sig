using System.Runtime.Serialization;

namespace Exchange.Contracts
{
    [DataContract]
    public class CommandMessage : Message
    {
        [DataMember]
        public AsyncCommands Command { get; set; }
    }
}
