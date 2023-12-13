using System;
using System.Web.Mvc;

namespace NetAppMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            string message = "Just a testing";
            ViewBag.Message = message;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult PartialViewDemo()
        {
            return PartialView();
        }

        public ActionResult SignIn()
        {
            return View();
        }
    }
}