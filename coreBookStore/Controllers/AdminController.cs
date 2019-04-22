using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreBookStore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace coreBookStore.Controllers
{
    [Route("account")]

    public class AdminController : Controller
    {
        private readonly BookStoreDbContext _context;

        public AdminController(BookStoreDbContext context)
        {
            _context = context;
        }

        [Route("")]
        [Route("index")]
        [Route("~/")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login(string username, string password)
        {

            //var user = _context.Admins.Where(x => x.AdminUserName == username).SingleOrDefault();
            //if (username == null)
            //{

            //    ViewBag.Error = "Invalid Credential";
            //    return View("Index");
            //}
            //else
            //{
            //    var userName = user.AdminUserName;
            //    var Password = user.AdminPassword;

            //    if (username != null && password != null && username.Equals(userName) && password.Equals(Password))
            //    {
            //        HttpContext.Session.SetString("uname", username);

            //        return View("Home");
            //    }
            //    else
            //    {
            //        ViewBag.Error = "Invalid Credential";
            //        return View("Index");
            //    }
            //}

            Admin ad = _context.Admins.Where(x => x.AdminUserName == username).SingleOrDefault();
            if (username != null && password != null && ad != null && password.Equals(ad.AdminPassword))
            {
                HttpContext.Session.SetString("uname", ad.AdminUserName );
                HttpContext.Session.SetString("id", ad.AdminId.ToString());
                return View("Home");
            }
            else
            {
                ViewBag.Error = "Invalid Credentials";
                return View("Index");
            }


        }

        public object Login()
        {
            throw new NotImplementedException();
        }

        [Route("Home")]

        public IActionResult Home()
        {

            return View();
        }

        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("uname");
            return RedirectToAction("Index");
        }


    }
}
