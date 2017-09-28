using Exchange.Contracts.ShowCase.CCIS;
using System.ServiceModel;

namespace Exchange.Contracts.Services
{

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [ServiceContract(Namespace = "https://push.flccis.com", ConfigurationName = "CCISPush")]
    public interface ICCISPush
    {

        // CODEGEN: Generating message contract since element name ucn from namespace  is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        submitDataResponse submitData(submitData request);

        [System.ServiceModel.OperationContractAttribute(Action = "", ReplyAction = "*")]
        System.Threading.Tasks.Task<submitDataResponse> submitDataAsync(submitData request);
    }
}
