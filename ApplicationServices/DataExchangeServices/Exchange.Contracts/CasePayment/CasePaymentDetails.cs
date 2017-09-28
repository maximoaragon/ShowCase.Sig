using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Exchange.Contracts
{
    [DataContract]
    public class CasePaymentDetails
    {
        private List<CasePaymentOption> m_CasePaymentOptions = new List<CasePaymentOption>();

        [DataMember]
        public string CaseID { get; set; }
        [DataMember]
        public string CaseNumber { get; set; }
        [DataMember]
        public string CitationNumber { get; set; }
        [DataMember]
        public decimal FeeBalance { get; set; }
        [DataMember]
        public DateTime OffenseDate { get; set; }
        [DataMember]
        public DateTime FileDate { get; set; }
        [DataMember]
        public string CaseType { get; set; }
        [DataMember]
        public bool IsCivil { get; set; }
        [DataMember]
        public string ErrorMsg { get; set; }
        [DataMember]
        public List<CasePaymentOption> CasePaymentOptions
        {
            get { return m_CasePaymentOptions; }
            set { m_CasePaymentOptions = value; }
        }
    }

    public class CasePaymentOption
    {
        public PaymentOptionType OptionType;
        public decimal Amount;
        public DateTime DueDate;
        public string Name;
        public string Description;
        public Boolean Selected;
        public Decimal MaxAmount;
        public Decimal MinAmount;
        public Boolean AllowPartialPayment;
        public string Disclaimer;
    }

    public enum PaymentOptionType { PayFees = 1, PayCitation, InCollections, SchoolElection, LateFees, PaymentPlan, Restitution, NotPayable };
}
