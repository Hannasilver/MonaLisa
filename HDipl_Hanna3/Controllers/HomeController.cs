using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HDipl_Hanna3.Models;

namespace HDipl_Hanna3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

           
            ViewBag.Message = "MonaLisa Beauty";

            return View();
        }

        public ActionResult Contact()
        {
           
            ViewBag.Message = "MonaLisa Beauty";

            return View();
        }


    }
}