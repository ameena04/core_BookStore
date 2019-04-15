using System;
using System.Collections.Generic;

namespace OnlineBookStoreUser.Models
{
    public partial class Payments
    {
        public int PaymentId { get; set; }
        public string StripePaymentId { get; set; }
        public float Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentDescription { get; set; }
        public long CardLastDigits { get; set; }
    }
}
