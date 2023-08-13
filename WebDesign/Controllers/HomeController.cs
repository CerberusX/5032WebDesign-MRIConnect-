using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebDesign.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "What is this?";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Find Your Favorite Place.";

            return View();
        }
    }
}