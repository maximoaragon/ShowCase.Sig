
using System.Runtime.Serialization;
namespace Exchange.Contracts.Imaging
{
    [DataContract(Name = "ImageEncodingType", Namespace = "http://schemas.datacontract.org/2004/07/ImagingUtil.DataProvider")]
    public enum ImageEncodingType
    {
        [EnumMember]
        UnKnown = 0,
        [EnumMember]
        TIFF = 1,
        [EnumMember]
        PDF = 2,
        [EnumMember]
        JPEG = 3,
        [EnumMember]
        BLOB = 4,
        [EnumMember]
        WORD = 5,
    }
}
