using System.Configuration;

namespace TwilioExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var accountSid = ConfigurationManager.AppSettings["TwilioAccountSid"];
            var authToken = ConfigurationManager.AppSettings["TwilioAuthToken"];

            var twilioSample = new TwilioSample(accountSid, authToken);
            var calls = twilioSample.GetCalls();


        }
    }
}
