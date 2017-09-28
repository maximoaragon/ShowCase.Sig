using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.Contracts.Imaging
{
    [Serializable]
    public class OcrRequest
    {
        public string FilePath { get; set; }
        public string  Email { get; set; }
        public SerializableDictionary<int, string> BookMarks { get; set; }
    }
}
