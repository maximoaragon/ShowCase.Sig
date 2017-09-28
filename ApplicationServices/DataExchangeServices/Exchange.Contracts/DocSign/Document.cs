using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.Contracts.DocSign
{
    public class Document
    {
        public string Name{ get; set; }
        public string FilePath { get; set; }
        public int ExternalID { get; set; }
        public int Pages { get; set; }
        public string Type { get; set; }
        public string FileData { get; set; }
        public string MetaData { get; set; }
        public IList<Signature> Signatures{ get; set; }
    }
}
