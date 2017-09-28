using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.Contracts.Imaging.AutoRedaction
{
    [Serializable]
    public class Page
    {
        public int PageNumber { get; set; }

        public string FilePath { get; set; }

        public byte[] Data { get; set; }
    }
}
