using System.ServiceModel;
using System.ServiceModel.Web;
using System.Threading.Tasks;

namespace Exchange.Contracts.Services
{
    [ServiceContract(Namespace = "http://showcase/2012/08/ExchangeWorkerService")]
    public interface IExchangeWorker
    {
        //[OperationContract(IsOneWay = true)]
        [WebInvoke(Method = "POST")]
        void ProcessExchangeRequest(ExchangeRequest request);

        [OperationContract()]
        [WebGet]
        Task CheckForRequests();
    }
}
