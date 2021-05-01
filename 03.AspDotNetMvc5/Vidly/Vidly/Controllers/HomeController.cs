using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Vidly.Controllers
{
    public class HomeController : Controller
    {
        //do not apply this attribute AFTER profiling page, not in beginning
        // it will show stale data. don't assume page will be slow
        [OutputCache(Duration = 50, Location = OutputCacheLocation.Server, VaryByParam = "")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            throw new Exception();

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}