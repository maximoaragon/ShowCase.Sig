using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exchange.Contracts.DocSign
{
    public class Signature
    {
        public int SigneeID { get; set; }
        public string SigneeName { get; set; }
        public int MediatorID { get; set; }
        public string SignatureTemplate { get; set; }
        public SignatureType Type{ get; set; }
        public SignatureStorage Storage { get; set; }
    }

    public enum SignatureType
    {
        User,
        Mediator
    }

    public enum SignatureStorage
    {
        None = 0,   //Do not store signature anywhere
        DuringSession = 1,
        Permanently = 2
    }
}
