using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpQueue.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "EFA Help Queue";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "EFA Contact";

            return View();
        }
    }
}