using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineBookStoreUser.Models;
using Stripe;

namespace OnlineBookStoreUser.Controllers
{
    public class PaymentController : Controller
    {
        Book_Store_DbContext context = new Book_Store_DbContext();

        private readonly Book_Store_DbContext _context;

        public PaymentController(Book_Store_DbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Charge(string stripeEmail, string stripeToken)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                SourceToken = stripeToken
            });

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = 500,
                Description = "Sample Charge",
                Currency = "usd",
                CustomerId = customer.Id
            });

            Payments payment = new Payments()
            {
                StripePaymentId = charge.PaymentMethodId,
                PaymentAmount = 500,
                
                DateOfPayment = System.DateTime.Now,
                PaymentDescription = "Payment Initiated..",
                CardLastDigit = Convert.ToInt32(charge.PaymentMethodDetails.Card.Last4),

                CustomerId = 1,
                OrderId = 2
            };

            _context.Add<Payments>(payment);

            _context.Payments.Add(payment);
            _context.SaveChanges();

            return RedirectToAction("Invoice", "Cart");
        }

    }
}