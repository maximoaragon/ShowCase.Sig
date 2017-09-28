using Exchange.Contracts.Imaging;
using Exchange.Contracts.Services;
using System;
using System.IO;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Exchange.ClientLib
{
    /// <summary>
    /// This client is used only for streaming images which uses different endpoint configuration.
    /// </summary>
    internal class ImageStreamingProviderServiceClient : ClientBase<IImageStreamingProviderService>, IImageStreamingProviderService
    {

        public ImageStreamingProviderServiceClient()
        {
        }

        public ImageStreamingProviderServiceClient(string endpointConfigurationName) :
            base(endpointConfigurationName)
        {
        }

        public ImageStreamingProviderServiceClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public ImageStreamingProviderServiceClient(string endpointConfigurationName, EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public ImageStreamingProviderServiceClient(System.ServiceModel.Channels.Binding binding, EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
        {
        }

        public Stream GetDocumentByPath(string documentPath, ImageEncodingType outputEncodingType, bool searchable)
        {
            return base.Channel.GetDocumentByPath(documentPath, outputEncodingType, searchable);
        }

        public Task<Stream> GetDocumentByPathAsync(string documentPath, ImageEncodingType outputEncodingType, bool searchable)
        {
            return base.Channel.GetDocumentByPathAsync(documentPath, outputEncodingType, searchable);
        }
    }

    public class ImageProviderServiceClient : ClientBase<IImageProviderService>, IImageProviderService
    {

        public ImageProviderServiceClient()
        {
        }

        public ImageProviderServiceClient(string endpointConfigurationName) :
            base(endpointConfigurationName)
        {
        }

        public ImageProviderServiceClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public ImageProviderServiceClient(string endpointConfigurationName, EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public ImageProviderServiceClient(System.ServiceModel.Channels.Binding binding, EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
        {
        }

        public int GetPageCount(string iri)
        {
            return base.Channel.GetPageCount(iri);
        }

        public Task<int> GetPageCountAsync(string iri)
        {
            return base.Channel.GetPageCountAsync(iri);
        }

        public ImageTransferObject GetImage(string iri)
        {
            return base.Channel.GetImage(iri);
        }

        public Task<ImageTransferObject> GetImageAsync(string iri)
        {
            return base.Channel.GetImageAsync(iri);
        }

        public void CreateContainer(ImageContainerObject ico)
        {
            base.Channel.CreateContainer(ico);
        }

        public Task CreateContainerAsync(ImageContainerObject ico)
        {
            return base.Channel.CreateContainerAsync(ico);
        }

        public string InsertImage(string iri, int index, ImageTransferObject ito)
        {
            return base.Channel.InsertImage(iri, index, ito);
        }

        public Task<string> InsertImageAsync(string iri, int index, ImageTransferObject ito)
        {
            return base.Channel.InsertImageAsync(iri, index, ito);
        }

        public string SaveRedactedImage(string inputIRI, int imageIndex, ImageTransferObject ito)
        {
            return base.Channel.SaveRedactedImage(inputIRI, imageIndex, ito);
        }

        public Task<string> SaveRedactedImageAsync(string inputIRI, int imageIndex, ImageTransferObject ito)
        {
            return base.Channel.SaveRedactedImageAsync(inputIRI, imageIndex, ito);
        }

        public string CopyImage(string inputIRIStr, int imageIndex, ImageTransferObject ito)
        {
            return base.Channel.CopyImage(inputIRIStr, imageIndex, ito);
        }

        public Task<string> CopyImageAsync(string inputIRIStr, int imageIndex, ImageTransferObject ito)
        {
            return base.Channel.CopyImageAsync(inputIRIStr, imageIndex, ito);
        }

        public string[] CopyImages(string[] inputIRIStr, ImageTransferObject ito)
        {
            return base.Channel.CopyImages(inputIRIStr, ito);
        }

        public Task<string[]> CopyImagesAsync(string[] inputIRIStr, ImageTransferObject ito)
        {
            return base.Channel.CopyImagesAsync(inputIRIStr, ito);
        }

        public void DeleteImage(string iri, int index)
        {
            base.Channel.DeleteImage(iri, index);
        }

        public Task DeleteImageAsync(string iri, int index)
        {
            return base.Channel.DeleteImageAsync(iri, index);
        }

        public void DeleteDocument(string iri)
        {
            base.Channel.DeleteDocument(iri);
        }

        public Task DeleteDocumentAsync(string iri)
        {
            return base.Channel.DeleteDocumentAsync(iri);
        }

        public string[] GetIRIFromMultiTiffFile(string iri)
        {
            return base.Channel.GetIRIFromMultiTiffFile(iri);
        }

        public Task<string[]> GetIRIFromMultiTiffFileAsync(string iri)
        {
            return base.Channel.GetIRIFromMultiTiffFileAsync(iri);
        }

        public ImageTransferObject CreateMultiPageDocument(string[] iriList, ImageEncodingType outputEncodingType, bool checkRedactionComplete, bool searchable)
        {
            return base.Channel.CreateMultiPageDocument(iriList, outputEncodingType, checkRedactionComplete, searchable);
        }

        public Task<ImageTransferObject> CreateMultiPageDocumentAsync(string[] iriList, ImageEncodingType outputEncodingType, bool checkRedactionComplete, bool searchable)
        {
            return base.Channel.CreateMultiPageDocumentAsync(iriList, outputEncodingType, checkRedactionComplete, searchable);
        }

        public string ERecordDocument(ImageTransferObject ito)
        {
            return base.Channel.ERecordDocument(ito);
        }

        public Task<string> ERecordDocumentAsync(ImageTransferObject ito)
        {
            return base.Channel.ERecordDocumentAsync(ito);
        }

        public string SealDocument(ImageTransferObject ito)
        {
            return base.Channel.SealDocument(ito);
        }

        public Task<string> SealDocumentAsync(ImageTransferObject ito)
        {
            return base.Channel.SealDocumentAsync(ito);
        }

        public string UnSealDocument(ImageTransferObject ito)
        {
            return base.Channel.UnSealDocument(ito);
        }

        public Task<string> UnSealDocumentAsync(ImageTransferObject ito)
        {
            return base.Channel.UnSealDocumentAsync(ito);
        }

        public string Redact(ImageTransferObject ito)
        {
            return base.Channel.Redact(ito);
        }

        public Task<string> RedactAsync(ImageTransferObject ito)
        {
            return base.Channel.RedactAsync(ito);
        }

        public void CancelRedaction(ImageTransferObject ito)
        {
            base.Channel.CancelRedaction(ito);
        }

        public Task CancelRedactionAsync(ImageTransferObject ito)
        {
            return base.Channel.CancelRedactionAsync(ito);
        }

        public int InsertFile(FileTransferObject fto)
        {
            return base.Channel.InsertFile(fto);
        }

        public Task<int> InsertFileAsync(FileTransferObject fto)
        {
            return base.Channel.InsertFileAsync(fto);
        }

        public void ReplaceFile(FileTransferObject fto)
        {
            base.Channel.ReplaceFile(fto);
        }

        public Task ReplaceFileAsync(FileTransferObject fto)
        {
            return base.Channel.ReplaceFileAsync(fto);
        }

        public void DeleteFile(int id, int index)
        {
            base.Channel.DeleteFile(id, index);
        }

        public Task DeleteFileAsync(int id, int index)
        {
            return base.Channel.DeleteFileAsync(id, index);
        }

        public FileTransferObject GetFile(int id, int index)
        {
            return base.Channel.GetFile(id, index);
        }

        public Task<FileTransferObject> GetFileAsync(int id, int index)
        {
            return base.Channel.GetFileAsync(id, index);
        }

        public int GetFileID(int id, int index)
        {
            return base.Channel.GetFileID(id, index);
        }

        public Task<int> GetFileIDAsync(int id, int index)
        {
            return base.Channel.GetFileIDAsync(id, index);
        }

        public int GetFileCount(int id)
        {
            return base.Channel.GetFileCount(id);
        }

        public Task<int> GetFileCountAsync(int id)
        {
            return base.Channel.GetFileCountAsync(id);
        }

        public string RedactionStatus(ImageTransferObject ito)
        {
            return base.Channel.RedactionStatus(ito);
        }

        public Task<string> RedactionStatusAsync(ImageTransferObject ito)
        {
            return base.Channel.RedactionStatusAsync(ito);
        }

        public string RetrieveDocument(ImageTransferObject ito)
        {
            return base.Channel.RetrieveDocument(ito);
        }

        public Task<string> RetrieveDocumentAsync(ImageTransferObject ito)
        {
            return base.Channel.RetrieveDocumentAsync(ito);
        }

        public Stream GetDocumentByPath(string documentPath, ImageEncodingType outputEncodingType, bool searchable)
        {
            var client = BuildChannel();
            return client.GetDocumentByPath(documentPath, outputEncodingType, searchable);
        }

        private IImageStreamingProviderService BuildChannel()
        {
            BasicHttpBinding binding = null;
            EndpointAddress address = null;

            var baseClient = new ImageProviderServiceClient() as ClientBase<IImageProviderService>;
            //Read client address based on the original ImageProviderServiceClient
            var uri = new Uri(baseClient.Endpoint.Address.Uri.ToString() + "/stream");
            address = new EndpointAddress(uri);
            baseClient.Close();

            binding = new BasicHttpBinding();
            binding.TransferMode = TransferMode.StreamedResponse;
            binding.MessageEncoding = WSMessageEncoding.Mtom;
            binding.MaxReceivedMessageSize = int.MaxValue;

            if (uri.ToString().ToLower().StartsWith("https://"))
                binding.Security.Mode = BasicHttpSecurityMode.Transport;

            ChannelFactory<IImageStreamingProviderService> factory = new ChannelFactory<IImageStreamingProviderService>(binding, address);
            factory.Endpoint.Behaviors.Clear();
            foreach (var b in baseClient.Endpoint.Behaviors)
            {
                factory.Endpoint.Behaviors.Add(b);
            }

            IImageStreamingProviderService channel = factory.CreateChannel();

            return channel;
        }
    }
}
