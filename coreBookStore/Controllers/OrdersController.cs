using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreBookStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace coreBookStore.Controllers
{
    public class OrdersController : Controller
    {
        private readonly BookStoreDbContext _context;

        public OrdersController(BookStoreDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var od = _context.Orders.ToList();
            return View(od);
            
        }
       

        public IActionResult Details(int id)
        {
            List<OrderBook> ob = new List<OrderBook>();
            List<Book> books = new List<Book>();
            ob = _context.OrderBooks.Where(x => x.OrderId == id).ToList();
            foreach (var item in ob)
            {
                Book c = _context.Books.Where(x => x.BookId == item.BookId).SingleOrDefault();
                books.Add(c);
            }
            ViewBag.bookDetail = books;
            return View();
        }

        //public object Details()
        //{
        //    throw new NotImplementedException();
        //}
    }
}