using humus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace humus.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("NewOrder", "orders");
            //return View();
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
        public ActionResult Error(Exception exception)
        {
            _DAL dal = new _DAL();

            dal.WriteLog("Error", exception.Message + " - " + exception.StackTrace);

            string message = "הודעה";

            var model = new ErrorViewModel(message, "");

            return View(model);
        }
    }
}