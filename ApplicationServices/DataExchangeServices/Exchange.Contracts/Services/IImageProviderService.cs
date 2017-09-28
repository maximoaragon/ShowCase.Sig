using Exchange.Contracts.Imaging;
using System.IO;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Exchange.Contracts.Services
{
    [ServiceContract(ConfigurationName = "ImageServiceReference.IImageStreamingProviderService")]
    public interface IImageStreamingProviderService
    {

        [OperationContractAttribute(Action = "http://tempuri.org/IImageStreamingProviderService/GetDocumentByPath", ReplyAction = "http://tempuri.org/IImageStreamingProviderService/GetDocumentByPathResponse")]
        Stream GetDocumentByPath(string documentPath, ImageEncodingType outputEncodingType, bool searchable);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageStreamingProviderService/GetDocumentByPath", ReplyAction = "http://tempuri.org/IImageStreamingProviderService/GetDocumentByPathResponse")]
        Task<Stream> GetDocumentByPathAsync(string documentPath, ImageEncodingType outputEncodingType, bool searchable);
    }

    [ServiceContractAttribute(ConfigurationName = "ImageServiceReference.IImageProviderService")]
    public interface IImageProviderService
    {

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/GetPageCount", ReplyAction = "http://tempuri.org/IImageProviderService/GetPageCountResponse")]
        int GetPageCount(string iri);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/GetPageCount", ReplyAction = "http://tempuri.org/IImageProviderService/GetPageCountResponse")]
        Task<int> GetPageCountAsync(string iri);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/GetImage", ReplyAction = "http://tempuri.org/IImageProviderService/GetImageResponse")]
        ImageTransferObject GetImage(string iri);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/GetImage", ReplyAction = "http://tempuri.org/IImageProviderService/GetImageResponse")]
        Task<ImageTransferObject> GetImageAsync(string iri);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/CreateContainer", ReplyAction = "http://tempuri.org/IImageProviderService/CreateContainerResponse")]
        void CreateContainer(ImageContainerObject ico);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/CreateContainer", ReplyAction = "http://tempuri.org/IImageProviderService/CreateContainerResponse")]
        Task CreateContainerAsync(ImageContainerObject ico);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/InsertImage", ReplyAction = "http://tempuri.org/IImageProviderService/InsertImageResponse")]
        string InsertImage(string iri, int index, ImageTransferObject ito);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/InsertImage", ReplyAction = "http://tempuri.org/IImageProviderService/InsertImageResponse")]
        Task<string> InsertImageAsync(string iri, int index, ImageTransferObject ito);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/SaveRedactedImage", ReplyAction = "http://tempuri.org/IImageProviderService/SaveRedactedImageResponse")]
        string SaveRedactedImage(string inputIRI, int imageIndex, ImageTransferObject ito);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/SaveRedactedImage", ReplyAction = "http://tempuri.org/IImageProviderService/SaveRedactedImageResponse")]
        Task<string> SaveRedactedImageAsync(string inputIRI, int imageIndex, ImageTransferObject ito);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/CopyImage", ReplyAction = "http://tempuri.org/IImageProviderService/CopyImageResponse")]
        string CopyImage(string inputIRIStr, int imageIndex, ImageTransferObject ito);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/CopyImage", ReplyAction = "http://tempuri.org/IImageProviderService/CopyImageResponse")]
        Task<string> CopyImageAsync(string inputIRIStr, int imageIndex, ImageTransferObject ito);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/CopyImages", ReplyAction = "http://tempuri.org/IImageProviderService/CopyImagesResponse")]
        string[] CopyImages(string[] inputIRIStr, ImageTransferObject ito);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/CopyImages", ReplyAction = "http://tempuri.org/IImageProviderService/CopyImagesResponse")]
        Task<string[]> CopyImagesAsync(string[] inputIRIStr, ImageTransferObject ito);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/DeleteImage", ReplyAction = "http://tempuri.org/IImageProviderService/DeleteImageResponse")]
        void DeleteImage(string iri, int index);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/DeleteImage", ReplyAction = "http://tempuri.org/IImageProviderService/DeleteImageResponse")]
        Task DeleteImageAsync(string iri, int index);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/DeleteDocument", ReplyAction = "http://tempuri.org/IImageProviderService/DeleteDocumentResponse")]
        void DeleteDocument(string iri);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/DeleteDocument", ReplyAction = "http://tempuri.org/IImageProviderService/DeleteDocumentResponse")]
        Task DeleteDocumentAsync(string iri);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/GetIRIFromMultiTiffFile", ReplyAction = "http://tempuri.org/IImageProviderService/GetIRIFromMultiTiffFileResponse")]
        string[] GetIRIFromMultiTiffFile(string iri);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/GetIRIFromMultiTiffFile", ReplyAction = "http://tempuri.org/IImageProviderService/GetIRIFromMultiTiffFileResponse")]
        Task<string[]> GetIRIFromMultiTiffFileAsync(string iri);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/CreateMultiPageDocument", ReplyAction = "http://tempuri.org/IImageProviderService/CreateMultiPageDocumentResponse")]
        ImageTransferObject CreateMultiPageDocument(string[] iriList, ImageEncodingType outputEncodingType, bool checkRedactionComplete, bool searchable);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/CreateMultiPageDocument", ReplyAction = "http://tempuri.org/IImageProviderService/CreateMultiPageDocumentResponse")]
        Task<ImageTransferObject> CreateMultiPageDocumentAsync(string[] iriList, ImageEncodingType outputEncodingType, bool checkRedactionComplete, bool searchable);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/ERecordDocument", ReplyAction = "http://tempuri.org/IImageProviderService/ERecordDocumentResponse")]
        string ERecordDocument(ImageTransferObject ito);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/ERecordDocument", ReplyAction = "http://tempuri.org/IImageProviderService/ERecordDocumentResponse")]
        Task<string> ERecordDocumentAsync(ImageTransferObject ito);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/SealDocument", ReplyAction = "http://tempuri.org/IImageProviderService/SealDocumentResponse")]
        string SealDocument(ImageTransferObject ito);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/SealDocument", ReplyAction = "http://tempuri.org/IImageProviderService/SealDocumentResponse")]
        Task<string> SealDocumentAsync(ImageTransferObject ito);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/UnSealDocument", ReplyAction = "http://tempuri.org/IImageProviderService/UnSealDocumentResponse")]
        string UnSealDocument(ImageTransferObject ito);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/UnSealDocument", ReplyAction = "http://tempuri.org/IImageProviderService/UnSealDocumentResponse")]
        Task<string> UnSealDocumentAsync(ImageTransferObject ito);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/Redact", ReplyAction = "http://tempuri.org/IImageProviderService/RedactResponse")]
        string Redact(ImageTransferObject ito);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/Redact", ReplyAction = "http://tempuri.org/IImageProviderService/RedactResponse")]
        Task<string> RedactAsync(ImageTransferObject ito);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/CancelRedaction", ReplyAction = "http://tempuri.org/IImageProviderService/CancelRedactionResponse")]
        void CancelRedaction(ImageTransferObject ito);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/CancelRedaction", ReplyAction = "http://tempuri.org/IImageProviderService/CancelRedactionResponse")]
        Task CancelRedactionAsync(ImageTransferObject ito);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/InsertFile", ReplyAction = "http://tempuri.org/IImageProviderService/InsertFileResponse")]
        int InsertFile(FileTransferObject fto);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/InsertFile", ReplyAction = "http://tempuri.org/IImageProviderService/InsertFileResponse")]
        Task<int> InsertFileAsync(FileTransferObject fto);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/ReplaceFile", ReplyAction = "http://tempuri.org/IImageProviderService/ReplaceFileResponse")]
        void ReplaceFile(FileTransferObject fto);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/ReplaceFile", ReplyAction = "http://tempuri.org/IImageProviderService/ReplaceFileResponse")]
        Task ReplaceFileAsync(FileTransferObject fto);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/DeleteFile", ReplyAction = "http://tempuri.org/IImageProviderService/DeleteFileResponse")]
        void DeleteFile(int id, int index);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/DeleteFile", ReplyAction = "http://tempuri.org/IImageProviderService/DeleteFileResponse")]
        Task DeleteFileAsync(int id, int index);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/GetFile", ReplyAction = "http://tempuri.org/IImageProviderService/GetFileResponse")]
        FileTransferObject GetFile(int id, int index);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/GetFile", ReplyAction = "http://tempuri.org/IImageProviderService/GetFileResponse")]
        Task<FileTransferObject> GetFileAsync(int id, int index);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/GetFileID", ReplyAction = "http://tempuri.org/IImageProviderService/GetFileIDResponse")]
        int GetFileID(int id, int index);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/GetFileID", ReplyAction = "http://tempuri.org/IImageProviderService/GetFileIDResponse")]
        Task<int> GetFileIDAsync(int id, int index);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/GetFileCount", ReplyAction = "http://tempuri.org/IImageProviderService/GetFileCountResponse")]
        int GetFileCount(int id);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/GetFileCount", ReplyAction = "http://tempuri.org/IImageProviderService/GetFileCountResponse")]
        Task<int> GetFileCountAsync(int id);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/RedactionStatus", ReplyAction = "http://tempuri.org/IImageProviderService/RedactionStatusResponse")]
        string RedactionStatus(ImageTransferObject ito);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/RedactionStatus", ReplyAction = "http://tempuri.org/IImageProviderService/RedactionStatusResponse")]
        Task<string> RedactionStatusAsync(ImageTransferObject ito);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/RetrieveDocument", ReplyAction = "http://tempuri.org/IImageProviderService/RetrieveDocumentResponse")]
        string RetrieveDocument(ImageTransferObject ito);

        [OperationContractAttribute(Action = "http://tempuri.org/IImageProviderService/RetrieveDocument", ReplyAction = "http://tempuri.org/IImageProviderService/RetrieveDocumentResponse")]
        Task<string> RetrieveDocumentAsync(ImageTransferObject ito);
    }
}
