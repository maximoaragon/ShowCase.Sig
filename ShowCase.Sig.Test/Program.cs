using Exchange.ClientLib.ShowCase;
using System;

namespace ShowCase.Sig.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            int times = 10;
            for (int i = 0; i < args.Length; i++)
                if (args[i] == "-t" && args.Length > i)
                    times = Convert.ToInt32(args[i + 1]);

            Console.WriteLine("****Testing Signature Process****");

            RequestSignature(times);

            Console.WriteLine("****Test ended****");

            Console.ReadLine();
        }

        static void RequestSignature(int times)
        {
            string[] waivers = new[] { "Reason 1", "Reason 2", "Reason x" };

            for (int i = 0; i < times; i++)
            {
                Console.WriteLine("Requesting Signature # {0} of {1}...", (i + 1).ToString(), times);
                try
                {
                    using (var client = new SignatureServiceClient())
                    {
                        string result = client.GetSignature("Test User " + (i + 1).ToString(), waivers);

                        Console.WriteLine("Response: {0}", result);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                    ShowCaseUtil.Logger.LogError("Signature # " + (i + 1).ToString() + " failed", ex);
                }
            }

            SignatureServiceClient.CloseProcess();
        }
    }
}
