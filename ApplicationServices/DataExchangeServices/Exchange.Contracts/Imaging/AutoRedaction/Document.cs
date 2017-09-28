using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.Contracts.Imaging.AutoRedaction
{
    [Serializable]
    public class Document
    {
        public int DocumentID { get; set; }

        string m_RedactID = "";
        public string RedactID {
            get
            {
                return m_RedactID;
            }
            set
            {
                m_RedactID = value;
            }
        }

        public List<Page> Pages { get; set; }
    }
}
