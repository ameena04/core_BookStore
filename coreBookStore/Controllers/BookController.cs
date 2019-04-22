using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreBookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace coreBookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookStoreDbContext _context;

        public BookController(BookStoreDbContext context)
        {
            _context = context;
        }
        public ViewResult Index()
        {
            var books = _context.Books.ToList();
            return View(books);
        }
        [HttpGet]
        public ViewResult Create()
        {
            
            ViewBag.authors = new SelectList(_context.Authors, "AuthorId", "AuthorName");
            ViewBag.categorys = new SelectList(_context.BookCategories, "BookCategoryId", "BookCategoryName");
            ViewBag.publications = new SelectList(_context.Publications, "PublicationId", "PublicationName");
           
            return View();
        }
        [HttpPost]
        public ActionResult Create(Book b1)
        {
            _context.Books.Add(b1);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Book bk = _context.Books.Find(id);

            return View(bk);
        }
        [HttpPost]
        public ActionResult Delete(int id, Book b1)
        {
            var bk = _context.Books.Where(x => x.BookId == id).SingleOrDefault();
            _context.Books.Remove(bk);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Book bk = _context.Books.Where(x => x.BookId == id).SingleOrDefault();
            ViewBag.authors = new SelectList(_context.Authors, "AuthorId", "AuthorName");
            ViewBag.categorys = new SelectList(_context.BookCategories, "BookCategoryId", "BookCategoryName");
            ViewBag.publications = new SelectList(_context.Publications, "PublicationId", "PublicationName");


            return View(bk);
        }
        [HttpPost]
        public ActionResult Edit(Book b1)
        {
            Book bk = _context.Books.Where
                (x => x.BookId == b1.BookId).SingleOrDefault();
            _context.Entry(bk).CurrentValues.SetValues(b1);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public object Edit(int id, Book book)
        {
            throw new NotImplementedException();
        }

        public ActionResult Details(int id)
        {
            Book bk = _context.Books.Where(x => x.BookId == id).SingleOrDefault();
            _context.SaveChanges();
            return View(bk);
        }
    }
}
