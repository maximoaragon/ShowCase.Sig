using System.Runtime.Serialization;

namespace Exchange.Contracts.ShowCase
{
    [DataContract]
    public class Officer
    {
        [DataMember]
        public string OfficerName { get; set; }
        [DataMember]
        public string BadgeNumber { get; set; }
    }
}
