using System.Web.Mvc;
using NetAppMVC.Models;

namespace NetAppMVC.Controllers
{
    public class TaskController : Controller
    {
        // GET
        public ActionResult Index(string id)
        {
            var model = new DataObj();
            model.Description = id;
            return View(model);
        }

        public ActionResult Buy()
        {
            var model = new DataObj();
            return Json(model);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}