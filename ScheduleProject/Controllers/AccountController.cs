using ScheduleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ScheduleProject.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        private List<LoginModel> users;
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index","Home");
            }
            return RedirectToAction("Login");
        }
        public AccountController()
        {
            this.users = new List<LoginModel>();
            users.Add(new LoginModel { Login = "itc_user", Password = "ITC2017" });
        }
         [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            var user = users.SingleOrDefault(x => x.Login == model.Login
                                   && x.Password == model.Password);
            if (user == null)
            {
                ViewBag.text = "Error";
                return View();
            }

            FormsAuthentication.SetAuthCookie(user.Login, true);
            return RedirectToAction("Index","Admin");
        }

     
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}