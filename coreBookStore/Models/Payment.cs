using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreBookStore.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public string StripePaymentId { get; set; }
        public float Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentDescription { get; set; }
        public long CardLastDigits { get; set; }
        
       

    }
}
