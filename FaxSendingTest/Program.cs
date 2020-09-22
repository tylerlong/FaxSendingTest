using System;
using System.IO;
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
                using (var rc = new RestClient(
                    Environment.GetEnvironmentVariable("RINGCENTRAL_CLIENT_ID"),
                    Environment.GetEnvironmentVariable("RINGCENTRAL_CLIENT_SECRET"),
                    Environment.GetEnvironmentVariable("RINGCENTRAL_SERVER_URL")
                ))
                {
                    Console.WriteLine(Environment.GetEnvironmentVariable("RINGCENTRAL_EXTENSION"));

                    await rc.Authorize(
                        Environment.GetEnvironmentVariable("RINGCENTRAL_USERNAME"),
                        Environment.GetEnvironmentVariable("RINGCENTRAL_EXTENSION"),
                        Environment.GetEnvironmentVariable("RINGCENTRAL_PASSWORD")
                    );

                    await rc.Restapi().Account().Extension().Fax().Post(new CreateFaxMessageRequest
                    {
                        attachments = new[]
                        {
                            new Attachment
                            {
                                fileName = "TestingFile.pdf",
                                contentType = "application/pdf",
                                bytes = File.ReadAllBytes(Environment.GetEnvironmentVariable("PDF_FILE_TO_SEND"))
                            }
                        },
                        to = new[]
                        {
                            new MessageStoreCalleeInfoRequest
                            {
                                phoneNumber = Environment.GetEnvironmentVariable("RINGCENTRAL_RECEIVER")
                            }
                        }
                    });
                    Console.WriteLine("Fax sent");
                }
            }).GetAwaiter().GetResult();
        }
    }
}