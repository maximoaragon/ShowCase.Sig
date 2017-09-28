using Exchange.Contracts.Services;
using ShowCaseUtil;
using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ShowCase.Sig
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
    public class SignatureService : ISignatureService, IDisposable
    {
        private ServiceHost _signatureService;

        public delegate string SignatureRequestEventHandler(string signeeName, string[] waivers);
        public static event SignatureRequestEventHandler OnSignatureRequest;
        
        public Task StartService()
        {
            return Task.Factory.StartNew(() =>
            {
                try
                {
                    _signatureService = new ServiceHost(typeof(SignatureService), new Uri[] { new Uri("net.pipe://localhost/ShowCase") });
                    _signatureService.AddServiceEndpoint(typeof(ISignatureService), new NetNamedPipeBinding(), "ShowCaseSignService");
                    _signatureService.Opened += _signatureService_Opened;
                    _signatureService.Open();

                    Logger.Log("Signature Service started");

                    Console.WriteLine("Service started. Available in following endpoints");
                    foreach (var serviceEndpoint in _signatureService.Description.Endpoints)
                        Logger.Log("Signature Service listening: " + serviceEndpoint, LogLevel.Verbose);
                    
                }catch(Exception ex)
                {
                    Logger.LogError("Unable to StartService", ex);
                }
            });
        }

        private void _signatureService_Opened(object sender, EventArgs e)
        {
            Logger.Log("SignatureService: Opened", LogLevel.Verbose);
        }

        public string GetSignature(string signeeName, string[] waiverReasons)
        {
            Logger.Log("Signature.GetSignature" + signeeName, LogLevel.Verbose);

            if (OnSignatureRequest != null)
                return OnSignatureRequest(signeeName, waiverReasons);

            return null;
        }

        public void Dispose()
        {
            if (_signatureService != null)
                try
                {
                    _signatureService.Close();
                }
                catch { }
        }
    }
}
