using System;
using System.Runtime.InteropServices;

namespace ShowCase.Sig
{
    public static class ErrorController
    {
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
