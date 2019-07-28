using System;
using System.Collections.Generic;
using System.Linq;
using Twilio;

namespace TwilioExample
{
    public interface ITwilioSample
    {
        IEnumerable<Call> GetCalls();
    }

    public class TwilioSample : ITwilioSample
    {
        private readonly string accountSid;
        private readonly string authToken;

        public TwilioSample(string accountSid, string authToken)
        {
            this.accountSid = accountSid;
            this.authToken = authToken;
        }

        public IEnumerable<Call> GetCalls()
        {
            var client = new TwilioRestClient(accountSid, authToken);
            var options = new CallListRequest();
            options.StartTimeComparison = ComparisonType.GreaterThanOrEqualTo;
            options.StartTime = DateTime.UtcNow.AddHours(-1);
            var callResult = client.ListCalls(options);

            if(callResult?.Calls == null || callResult.Calls.Count == 0)
            {
                return Enumerable.Empty<Call>();
            }

            return callResult.Calls;
        }
    }
}
