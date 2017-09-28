using Exchange.Contracts.Services;
using ShowCaseUtil;
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Threading;

namespace Exchange.ClientLib.ShowCase
{
    public class SignatureServiceClient : ISignatureService, IDisposable
    {
        public const string SRV_PROC_NAME = "ShowCase.Sig.exe";

        private int _retries = 5;

        private Process _sigProcess = null;

        private static Binding _binding = new NetNamedPipeBinding()
        {
            OpenTimeout = TimeSpan.FromMinutes(60),
            CloseTimeout = TimeSpan.FromMinutes(60),
            ReceiveTimeout = TimeSpan.FromMinutes(60),
            SendTimeout = TimeSpan.FromMinutes(60),
            MaxReceivedMessageSize = (500 * 1024) //signatures should not be over 200kb
        };

        private static EndpointAddress _add = new EndpointAddress("net.pipe://localhost/ShowCase/ShowCaseSignService");

        private ISignatureService _proxy;
        private ChannelFactory<ISignatureService> _channel;

        /// <summary>
        /// Kills the ShowCase.Sig.exe process if any is running.
        /// </summary>
        public static void CloseProcess()
        {
            string procName = Path.GetFileNameWithoutExtension(SRV_PROC_NAME);
            foreach (var p in Process.GetProcesses())
            {
                if (p.ProcessName == procName)
                {
                    Logger.Log("CloseProcess", LogLevel.Verbose);
                    try
                    {
                        p.Kill();
                        p.WaitForExit();
                    }
                    catch { }
                }
            }
        }

        public SignatureServiceClient()
        {

            StartShowCaseSigProcess(false);

            _channel = new ChannelFactory<ISignatureService>(new ServiceEndpoint(ContractDescription.GetContract(typeof(ISignatureService)), _binding, _add));
            _proxy = _channel.CreateChannel();
        }

        public string GetSignature(string signeeName, string[] waiverReasons)
        {
            try
            {
                return _proxy.GetSignature(signeeName, waiverReasons);
            }
            catch(Exception ex)
            {
                _retries--;
                if (_retries > 0)
                {
                    Logger.Log("GetSignature: Retry", LogLevel.Information);
                    Thread.Sleep(2000);

                    StartShowCaseSigProcess(true);

                    _channel = new ChannelFactory<ISignatureService>(new ServiceEndpoint(ContractDescription.GetContract(typeof(ISignatureService)), _binding, _add));
                    _proxy = _channel.CreateChannel();

                    return GetSignature(signeeName, waiverReasons);
                }
                throw new Exception("Unable to connect to the ShowCaseSignService ", ex);   
            }
        }

        private void StartShowCaseSigProcess(bool restart)
        {
            string procName = Path.GetFileNameWithoutExtension(SRV_PROC_NAME);
            string procPath = ConfigurationManager.AppSettings["ShowCaseSigPath"];

            if (string.IsNullOrEmpty(procPath))
                procPath = SRV_PROC_NAME;

            foreach (var p in Process.GetProcesses())
            {
                if (p.ProcessName == procName)
                {
                    _sigProcess = p;
                    _sigProcess.EnableRaisingEvents = true;
                    _sigProcess.Exited += sigProcess_Exited;

                    Logger.Log("StartShoCaseSigProcess: ShowCase.Sig is already running");
                    return; //skip start
                }
            }

            if (File.Exists(procPath))
            {
                var originalErrorMode = SetErrorMode(ErrorModes.SEM_NOGPFAULTERRORBOX);

                _sigProcess = Process.Start(procPath, restart? "-r":"");
                _sigProcess.EnableRaisingEvents = true;
                _sigProcess.Exited += sigProcess_Exited;

                Logger.Log("StartShoCaseSigProcess: ShowCase.Sig started");
                Thread.Sleep(2000); 
            }
        }

        private void sigProcess_Exited(object sender, EventArgs e)
        {
            Logger.LogWarning(SRV_PROC_NAME + " has exited", null);
        }

        public void Dispose()
        {
            //do not Dispose _sigProcess. It needs to keep running.
            if (_sigProcess != null)
                _sigProcess.Exited -= sigProcess_Exited;

            SetErrorMode(ErrorModes.SYSTEM_DEFAULT); //reset to default error mode

            try
            { _channel.Close(); }
            catch { }
        }

        /// <summary>
        /// This function controls the system-level errors (out of the CLR) and allows the WER to be skipped.
        /// https://blogs.msdn.microsoft.com/oldnewthing/20040727-00/?p=38323
        /// </summary>
        /// <param name="uMode"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        public static extern ErrorModes SetErrorMode(ErrorModes uMode);

        [Flags]
        public enum ErrorModes : uint
        {
            SYSTEM_DEFAULT = 0x0,
            SEM_FAILCRITICALERRORS = 0x0001,
            SEM_NOALIGNMENTFAULTEXCEPT = 0x0004,
            SEM_NOGPFAULTERRORBOX = 0x0002,
            SEM_NOOPENFILEERRORBOX = 0x8000
        }
        
    }
}
