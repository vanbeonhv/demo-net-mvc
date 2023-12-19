using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DataAccess.DataAccessObjectImpl;
using DataAccess.DataObject;

namespace NetAppMVC.Controllers
{
    public class MemberController : Controller
    {
        // GET
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UsersPartialView()
        {
            var model = new List<User>();
            try
            {
                model = new UserDaoImpl().GetListUser();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return PartialView(model);
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Delete()
        {
            return Json("Deleted");
        }
    }
}