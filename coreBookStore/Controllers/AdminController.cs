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
        BookStoreDbContext context = new BookStoreDbContext();
        [Route("")]
            [Route("index")]
            [Route("~/")]
            [HttpGet]
            public IActionResult Index()
            {
                return View();
            }

        //[Route("login")]
        //[HttpPost]
        //public IActionResult Login(string username, string password)
        //{
        //    if (username != null && password != null && username.Equals("admin") && password.Equals("123456"))
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

        [Route("login")]
        [HttpPost]
        public IActionResult Login(int id, Admin admin)
        {
            var adminLogin = context.Admins.Where(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword.Equals(admin.AdminPassword)).SingleOrDefault();
            if (adminLogin == null)
            {
                ViewBag.Error = "Invalid Credential";
                return View("Login");
            }
            else
            {
                //int adminId = adminLogin.AdminId;
                //ViewBag.adminUserName = adminLogin.AdminUserName;

                if (adminLogin != null)
                {

                    HttpContext.Session.SetString("uname", adminLogin.AdminUserName);
                    //HttpContext.Session.SetString("id", adminLogin.AdminId.ToString());

                    //HttpContext.Session.SetString("cid", adminId.ToString());
                   
                        return RedirectToAction("Home");



                }
                else
                {
                    ViewBag.Error = "Invalid Credential";
                    return View("Index");
                }

            }

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