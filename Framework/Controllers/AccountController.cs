using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Framework.Models;
using Microsoft.AspNetCore.Http;

namespace Framework.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AccountController (ApplicationDbContext db)
        {
            _db = db;
        }
        public Account account { get; set; }
        //Registration Action

        [HttpGet]
        public IActionResult Index()
        {
            if (Request.Cookies["LastLoggedInTime"] != null)
            {
                ViewBag.LTLD = Request.Cookies["LastLoggedInTime"].ToString();
            }
            return View();
        }

        [HttpPost]
        public IActionResult Index(Account account)
        {
            Account LoggedInUser = _db.Accounts.Where(x => x.USERNAME == account.USERNAME && x.PASSWD == account.PASSWD).FirstOrDefault();
            if(LoggedInUser == null)
            {
                ViewBag.Message = " Wrong Username or Password, Please try again!";
                return View();
            }
            HttpContext.Session.SetString("Username", LoggedInUser.USERNAME);
            Response.Cookies.Append("LastLoggedInTime", DateTime.Now.ToString());
            return RedirectToAction("Dashboard");
        }

        public IActionResult Dashboard()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Username")))
            {
                return RedirectToAction("Index");
            }
            ViewBag.Username = HttpContext.Session.GetString("Username");
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }





    }
}
