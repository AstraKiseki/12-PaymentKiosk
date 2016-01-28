using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentKiosk.Core.Domain;
using Stripe;

namespace PaymentKiosk.Core.Services
{
    public class MoneyService
    {
        private const string StripeApiKey = "sk_test_ReQsIW6S9uNMMhPiGLV09Qpe";

        public static bool Charge(Customer customer, CreditCard creditCard, decimal amount)
        {
            // call Stripe API

            var chargeDetails = new StripeChargeCreateOptions();

            chargeDetails.Amount = (int)amount * 100;
            chargeDetails.Currency = "usd";

            chargeDetails.Source = new StripeSourceOptions
            {
                Object = "card",
                Number = creditCard.CardNumber,
                ExpirationMonth = creditCard.ExpiryDate.Month.ToString(),
                ExpirationYear = creditCard.ExpiryDate.Year.ToString(),
                Cvc = creditCard.SecurityCode

            };

            var chargeService = new StripeChargeService(StripeApiKey);
            var response = chargeService.Create(chargeDetails);

            if (response.Paid == false)
            {
                throw new Exception(response.FailureMessage);
            }

            return response.Paid;

        }
    }
}
