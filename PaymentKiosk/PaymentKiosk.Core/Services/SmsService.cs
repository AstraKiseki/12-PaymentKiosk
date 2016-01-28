using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;

namespace PaymentKiosk.Core.Services
{
        public class SmsService
        {
            private const string TwilioAccountSid = "AC13d62734b3560a6ce4ca41108ec0135b";
            private const string TwilioAuthToken = "724a6272c20fd9d4a2aad541ca7e51a5";
            private const string FromNumber = "+18582014064";

            public static void SendSms(string to, string message)
            {
                var twilio = new TwilioRestClient(TwilioAccountSid, TwilioAuthToken);

                twilio.SendMessage(FromNumber, to, message);
            }
        }
    }

