using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DataAccess.DataAccessObjectImpl;
using DataAccess.DataObject;
using NetAppMVC.Enum;
using NetAppMVC.Models;

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

        public ActionResult Edit(Guid id)
        {
            var model = new User();
            var modeCode = id != Guid.Empty ? ModeCode.Edit : ModeCode.Add;
            try
            {
                model = id != Guid.Empty ? new UserDaoImpl().GetUer(id) : model;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            ViewBag.ModeCode = (int)modeCode;
            return View(model);
        }

        public ActionResult EditResult(User user)
        {
            var result = new ResponseData();
            try
            {
                result.Status = new UserDaoImpl().UpdateUser(user);
                switch (result.Status)
                {
                    case 1:
                        result.Message = "Update success";
                        break;
                    case -1:
                        result.Message = "User Id not found";
                        break;
                    default:
                        result.Message = "System error";
                        break;
                }
            }
            catch (Exception e)
            {
                result.Status = -777;
                result.Message = e.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // [HttpDelete]
        public ActionResult DeleteResult(Guid id)
        {
            var result = new ResponseData();
            try
            {
                result.Status = new UserDaoImpl().RemoveUser(id);
                switch (result.Status)
                {
                    case 1:
                        result.Message = "Remove user success";
                        break;
                    case -1:
                        result.Message = "User Id not found";
                        break;
                    default:
                        result.Message = "System error";
                        break;
                }
            }
            catch (Exception e)
            {
                result.Status = -666;
                result.Message = e.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult AddResult(User user)
        {
            var result = new ResponseData();
            try
            {
                result.Status = new UserDaoImpl().AddNewUser(user);
                switch (result.Status)
                {
                    case 1:
                        result.Message = "Add user success";
                        break;
                    default:
                        result.Message = "System error";
                        break;
                }
            }
            catch (Exception e)
            {
                result.Status = -666;
                result.Message = e.Message;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}