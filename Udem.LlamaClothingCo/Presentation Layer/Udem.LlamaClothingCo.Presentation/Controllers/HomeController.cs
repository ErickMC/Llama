using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Udem.LlamaClothingCo.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Clothing Co Store";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
