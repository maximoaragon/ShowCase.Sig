using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Exchange.Contracts.ShowCase
{
    [DataContract]
    public class ROARequest
    {
        [DataMember]
        [XmlAttribute]
        public int CaseID { get; set; }

        [DataMember]
        [XmlAttribute]
        public bool Searchable { get; set; }

        [DataMember]
        [XmlAttribute]
        public bool Redacted { get; set; }

        [DataMember]
        public List<ROADocument> Documents { get; set; }
    }

    [DataContract]
    public class ROADocument
    {
        [DataMember]
        public string FileDescription { get; set; }
        
        [DataMember]
        public string FilePath { get; set; }

        [DataMember]
        public long FileSize { get; set; }

        [DataMember]
        public byte[] FileBinary { get; set; }

        [DataMember]
        public int DocketID { get; set; }

        [DataMember]
        public int StartingPage { get; set; }
        
        [DataMember]
        public int EndingPage { get; set; }

        [DataMember]
        public bool Confidential { get; set; }
    }
}
