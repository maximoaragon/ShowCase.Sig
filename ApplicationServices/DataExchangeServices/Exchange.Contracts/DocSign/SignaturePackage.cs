using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.Contracts.DocSign
{
    public class SignaturePackage
    {
        public IList<Document> Documents { get; set; }
        public string SignatureRoom { get; set; }
        public string PackageName { get; set; }
    }
}
