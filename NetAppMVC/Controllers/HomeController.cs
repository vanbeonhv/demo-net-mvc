using System;
using System.Web.Mvc;
using DataAccess;
using DataAccess.DataAccessObjectImpl;
using Microsoft.Ajax.Utilities;
using NetAppMVC.Models;

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

        public ActionResult SignInView()
        {
            return View();
        }

        public JsonResult SignIn(SignInRequestData result)
        {
            var responseData = new ResponseData();
            if (string.IsNullOrEmpty(result.Email) || string.IsNullOrEmpty(result.Password))
            {
                responseData.Message = "Sign In value invalid";
            }
            else if (result.Password.Length < 6)
            {
                responseData.Message = "Password must be at least 6 characters";
            }
            else
            {
                responseData.Message = "Sign in success!";
            }

            return Json(responseData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Login(SignInRequestData result)
        {
            var responseData = new ResponseData();
            if (string.IsNullOrEmpty(result.Email) || string.IsNullOrEmpty(result.Password))
            {
                responseData.Message = "Sign In value invalid";
            }
            else if (result.Password.Length < 6)
            {
                responseData.Message = "Password must be at least 6 characters";
            }
            else
            {
                responseData.Message = "Login success!";
                var user = new UserDaoImpl().GetUser();
                var i = 1;
            }

            return Json(responseData, JsonRequestBehavior.AllowGet);
        }
    }
}