using Challenge4.Website.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Challenge4.Website.Controllers
{
    public class HomeController : Controller
    {

        private Entities db = new Entities();

        [RequireHttps]
        public ActionResult Index()
        {
            AspNetUser currentUser;
            string userId = User.Identity.GetUserId();
            if (userId != null)
            {
                currentUser = db.AspNetUsers.SingleOrDefault(m => m.Id == userId);
            }
            else
            {
                currentUser = new AspNetUser();
                currentUser.EmailConfirmed = false;
            }

            return View(currentUser);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}