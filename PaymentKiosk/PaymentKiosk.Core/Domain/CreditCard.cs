using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentKiosk.Core.Domain
{
    public class CreditCard
    {
        public string CardNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string SecurityCode { get; set; }
        public Address BillingAddress { get; set; }
    }
}
