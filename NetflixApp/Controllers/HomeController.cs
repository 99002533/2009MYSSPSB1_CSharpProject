using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NetflixApp.Models;

namespace NetflixApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
          
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                SeriesDBEntities1 db = new SeriesDBEntities1();
                var user = (from userlist in db.LoginTables
                            where userlist.Username == login.Username && userlist.Password == login.Password
                            select new
                            {
                                userlist.Id,
                                userlist.Username,
                                userlist.Password
                            }).ToList();
                if (user.FirstOrDefault() != null)
                {
                    Session["Username"] = user.FirstOrDefault().Username;
                    Session["Id"] = user.FirstOrDefault().Id;
                    return Redirect("/Netflix/Details");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login credentials.");
                }
            }
            return View(login);
        }

    }
}