using System.Runtime.Serialization;

namespace Exchange.Contracts
{
    [DataContract]
    public class SubmitPaymentRequest
    {

        [DataMember]
        public string CaseID { get; set; }        
        [DataMember]
        public string PaymentAmount { get; set; }
        [DataMember]
        public string AuthCode { get; set; }

    }    
}
