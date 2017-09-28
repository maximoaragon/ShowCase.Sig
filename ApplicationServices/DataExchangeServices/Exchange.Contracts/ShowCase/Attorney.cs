using System.Runtime.Serialization;

namespace Exchange.Contracts.ShowCase
{
    [DataContract]
    public class Attorney
    {
        [DataMember]
        public string AttorneyName {get; set;}
        [DataMember]
        public string BarNumber {get; set;}
    }
}
