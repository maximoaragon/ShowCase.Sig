using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Exchange.Contracts
{
    [DataContract]
    public class GetPaymentsResponse
    {

        private List<CaseFee> m_CaseFees = new List<CaseFee>();

        [DataMember]
        public string CaseID { get; set; }
        [DataMember]
        public string CaseNumber { get; set; }
        [DataMember]
        public string CitationNumber { get; set; }
        [DataMember]
        public string ErrorMsg { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public List<CaseFee> CaseFees
        {
            get { return m_CaseFees; }
            set { m_CaseFees = value; }
        }

        public class CaseFee
        {
            public int FeeID;
            public string Description;
            public decimal Balance;
        }

    }
}
