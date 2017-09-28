using Exchange.Contracts.Services;
using Exchange.Contracts.ShowCase.CCIS;
using System.ServiceModel;

namespace Exchange.ClientLib
{
    public class CCISPushClient : ClientBase<ICCISPush>, ICCISPush
    {

        public CCISPushClient()
        {
        }

        public CCISPushClient(string endpointConfigurationName) :
            base(endpointConfigurationName)
        {
        }

        public CCISPushClient(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public CCISPushClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
        {
        }

        public CCISPushClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
        {
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        submitDataResponse ICCISPush.submitData(submitData request)
        {
            return base.Channel.submitData(request);
        }

        public string submitData(string ucn, Exchange.Contracts.ShowCase.CCIS.ccisFile ccisFile, string xml)
        {
            submitData inValue = new submitData();
            inValue.Body = new submitDataBody();
            inValue.Body.ucn = ucn;
            inValue.Body.ccisFile = ccisFile;
            inValue.Body.xml = xml;
            submitDataResponse retVal = ((ICCISPush)(this)).submitData(inValue);
            return retVal.Body.key;
        }

        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<submitDataResponse> ICCISPush.submitDataAsync(submitData request)
        {
            return base.Channel.submitDataAsync(request);
        }

        public System.Threading.Tasks.Task<submitDataResponse> submitDataAsync(string ucn, Exchange.Contracts.ShowCase.CCIS.ccisFile ccisFile, string xml)
        {
            submitData inValue = new submitData();
            inValue.Body = new submitDataBody();
            inValue.Body.ucn = ucn;
            inValue.Body.ccisFile = ccisFile;
            inValue.Body.xml = xml;
            return ((ICCISPush)(this)).submitDataAsync(inValue);
        }
    }
}
