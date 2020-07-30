using System;
using System.Threading.Tasks;
using dotenv.net;
using RingCentral;

namespace FaxSendingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            DotEnv.Config(true);
            
            Task.Run(async () =>
            {
                Console.WriteLine("Hello world!");

                // using (var rc = new RestClient(
                //     Environment.GetEnvironmentVariable("RINGCENTRAL_CLIENT_ID"),
                //     Environment.GetEnvironmentVariable("RINGCENTRAL_CLIENT_SECRET"),
                //     Environment.GetEnvironmentVariable("RINGCENTRAL_SERVER_URL")
                // ))
                // {
                //     await rc.Authorize(
                //         Environment.GetEnvironmentVariable("RINGCENTRAL_USERNAME"),
                //         Environment.GetEnvironmentVariable("RINGCENTRAL_EXTENSION"),
                //         Environment.GetEnvironmentVariable("RINGCENTRAL_PASSWORD")
                //     );
                // }

            }).GetAwaiter().GetResult();
        }
    }
}