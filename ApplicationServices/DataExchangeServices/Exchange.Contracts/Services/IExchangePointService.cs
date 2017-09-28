using System.ServiceModel;
using System.ServiceModel.Web;
using System.Xml;
using Exchange.Contracts;

namespace Exchange.Contracts.Services
{
    [ServiceContract(Namespace = "http://showcase/2012/08/ExchangePoint")]
    [XmlSerializerFormat]
    public interface IExchangePointService
    {
        [OperationContract]
        [WebGet(UriTemplate = "*")]
        ExchangeResponse GetData();

        [OperationContract]
        [WebInvoke(UriTemplate = "*", Method = "POST")]
        ExchangeResponse CreateUpdateData(XmlElement userData);
    }
}
