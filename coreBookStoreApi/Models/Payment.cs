using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace coreBookStoreApi.Models
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentId { get; set; }
        public string StripePaymentId { get; set; }
        public float PaymentAmount { get; set; }
        public DateTime DateOfPayment { get; set; }
        public string PaymentDescription { get; set; }
        public long CardLastDigit { get; set; }
        public int CustomerId { get; set; }
        public int OrderId { get; set; }

        public Order Order { get; set; }
       

        
    }
}
