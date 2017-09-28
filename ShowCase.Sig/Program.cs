using ShowCaseUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShowCase.Sig
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, args) => CurrentDomain_UnhandledException(args.ExceptionObject as Exception);
            Application.ThreadException += (sender, args) => CurrentDomain_UnhandledException(args.Exception);
           
            ErrorController.SetErrorMode(ErrorController.ErrorModes.SEM_NOGPFAULTERRORBOX);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmSignature());
        }

        private static void CurrentDomain_UnhandledException(Exception e)
        {
            Logger.LogError("ShowCase.Sig error," , e);
        }
    }
}
