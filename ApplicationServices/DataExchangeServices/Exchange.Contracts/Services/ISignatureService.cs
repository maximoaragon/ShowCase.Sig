using System.ServiceModel;

namespace Exchange.Contracts.Services
{
    [ServiceContract()]
    public interface ISignatureService
    {
        [OperationContract]
        string GetSignature(string signeeName, string[] waiverReasons);
    }
}
