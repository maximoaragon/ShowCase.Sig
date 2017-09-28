using System.Runtime.Serialization;

namespace Exchange.Contracts.Imaging
{
    [DataContractAttribute(Name = "ImageRedactionType", Namespace = "http://schemas.datacontract.org/2004/07/ImagingUtil.DataProvider")]
    public enum ImageRedactionType : int
    {

        [EnumMember()]
        UnKnown = 0,

        [EnumMember()]
        Original = 1,

        [EnumMember()]
        Redacted = 2,

        [EnumMember()]
        Secured = 3,

        [EnumMember()]
        Sealed = 4,
    }
}
