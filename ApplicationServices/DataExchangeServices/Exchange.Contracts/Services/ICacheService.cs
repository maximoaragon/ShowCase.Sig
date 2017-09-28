using Exchange.Contracts.ShowCase;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Exchange.Contracts.Services
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [ServiceContract]
    public interface ICacheService
    {

        [OperationContract]
        CachedDataTableResponse GetCachedDataTable(CachedDataTableRequest cacheRequest);

        [OperationContract]
        Task<CachedDataTableResponse> GetCachedDataTableAsync(CachedDataTableRequest cacheRequest);
    }
}
