using Exchange.Contracts.Services;
using ShowCaseUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShowCase.Sig
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
              ConcurrencyMode = ConcurrencyMode.Single)]
    public class SignatureService : ISignatureService, IDisposable
    {
        private ServiceHost _signatureService;

        public delegate byte[] SignatureRequestEventHandler(string signeeName, string[] waivers);
        public static event SignatureRequestEventHandler OnSignatureRequest;
        
        public Task StartService()
        {
            return Task.Factory.StartNew(() =>
            {
                try
                {
                    _signatureService = new ServiceHost(typeof(SignatureService), new Uri[] { new Uri("net.pipe://localhost/ShowCase") });
                    _signatureService.AddServiceEndpoint(typeof(ISignatureService), new NetNamedPipeBinding(), "ShowCaseSignService");
                    _signatureService.Open();

                    Logger.Log("Signature Service started");

                    Console.WriteLine("Service started. Available in following endpoints");
                    foreach (var serviceEndpoint in _signatureService.Description.Endpoints)
                    {
                        Logger.Log("Signature Service listening: " + serviceEndpoint, LogLevel.Verbose);
                    }
                }catch(Exception ex)
                {
                    Logger.LogError("Unable to StartService", ex);
                }
            });
        }

        public byte[] GetSignature(string signeeName, string[] waiverReasons)
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
