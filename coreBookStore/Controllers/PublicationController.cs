using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreBookStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace coreBookStore.Controllers
{
    public class PublicationController : Controller
    {
        private readonly BookStoreDbContext _context;

        public PublicationController(BookStoreDbContext context)
        {
            _context = context;
        }
        public ViewResult Index()
        {
            var publications = _context.Publications.ToList();
            return View(publications);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind("PublicationName,PublicationDescription,PublicationImage")]Publication p1)
        {
            if (ModelState.IsValid)
            {
               
                _context.Publications.Add(p1);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(p1);
        }

        public ActionResult Details(int id)
        {
            Publication Pub = _context.Publications.Where(x => x.PublicationId == id).SingleOrDefault();
            _context.SaveChanges();
            return View(Pub);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Publication Pub = _context.Publications.Find(id);

            return View(Pub);
        }
        [HttpPost]
        public ActionResult Delete(int id, Author p1)
        {
            var Pub = _context.Publications.Where(x => x.PublicationId == id).SingleOrDefault();
            _context.Publications.Remove(Pub);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Publication Pub = _context.Publications.Where(x => x.PublicationId == id).SingleOrDefault();


            return View(Pub);
        }
        [HttpPost]
        public ActionResult Edit(Publication p1)
        {
           
                Publication Pub = _context.Publications.Where
                (x => x.PublicationId == p1.PublicationId).SingleOrDefault();

                _context.Entry(Pub).CurrentValues.SetValues(p1);
                _context.SaveChanges();
                return RedirectToAction("Index");
            
            //return View(p1);
        }

        public object Edit(int id, Publication pub)
        {
            throw new NotImplementedException();
        }
    }
}
