using System.Runtime.Serialization;

namespace Exchange.Contracts.ShowCase
{
    [DataContract]
    public class Agency
    {
        [DataMember]
        public string AgencyName { get; set; }
        [DataMember]
        public string ORI { get; set; }
    }
}
    