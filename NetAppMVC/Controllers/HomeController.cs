using System;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataAccess;
using DataAccess.DataAccessObjectImpl;
using DataAccess.DataObject;
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

        public ActionResult Welcome()
        {
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
                responseData.Message = "Email and password can't be blank";
            }
            else if (result.Password.Length < 6)
            {
                responseData.Message = "Password must be at least 6 characters";
            }
            else
            {
                HttpStatusCode httpCodeRes = new UserDaoImpl().AddNewUser(result.Email, result.Password);
                responseData.Status = (int)httpCodeRes;
                switch (httpCodeRes)
                {
                    case HttpStatusCode.Created:
                        responseData.Message = "Sign in successfully";
                        break;
                    case HttpStatusCode.Conflict:
                        responseData.Message = "Email already exits";
                        break;
                    default:
                        responseData.Message = "Error";
                        break;
                }
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
                int httpStatusReturn = new UserDaoImpl().Login(result.Email, result.Password);
                responseData.Status = httpStatusReturn;
                responseData.Message = (httpStatusReturn == (int)HttpStatusCode.OK)
                    ? "Login success!"
                    : "Invalid email or password!";
            }

            return Json(responseData, JsonRequestBehavior.AllowGet);
        }
    }
}