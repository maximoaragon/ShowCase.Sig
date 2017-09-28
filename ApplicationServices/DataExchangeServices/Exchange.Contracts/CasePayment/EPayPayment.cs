using System.Runtime.Serialization;
using System;

namespace Exchange.Contracts
{
     [DataContract]
    public class EPAYPayment
    {

        [DataMember]
        public string CaseID { get; set; }
        [DataMember]
        public string PaymentAmount { get; set; }
        [DataMember]
        public int PaymentOption { get; set; }
        [DataMember]
        public string PayeeName { get; set; }
        [DataMember]
        public string PayeeAddress { get; set; }
        [DataMember]
        public string PayeeCity { get; set; }
        [DataMember]
        public string PayeeState { get; set; }
        [DataMember]
        public string PayeeZip { get; set; }
        [DataMember]
        public string PSPID { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string ExpMonth { get; set; }
        [DataMember]
        public string ExpYear { get; set; }
        [DataMember]
        public string ReferenceInfo { get; set; }
        [DataMember]
        public string ConvenienceFeeAmount { get; set; }
        [DataMember]
        public DateTime? PaymentDate { get; set; }
    }
}
