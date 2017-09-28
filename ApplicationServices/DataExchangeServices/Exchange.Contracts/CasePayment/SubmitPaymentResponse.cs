using System.Runtime.Serialization;


namespace Exchange.Contracts
{
    [DataContract]
    public class SubmitPaymentResponse
    {

        [DataMember]
        public string ReceiptNumber { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string ErrorMsg { get; set; }

    }
}
