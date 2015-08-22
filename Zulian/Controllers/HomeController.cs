using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Zulian.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            String str = Request.Form.ToString();
            if (Request.Form.Count > 0)
                return Redirect("Home/Done");
            return View();
        }

        public ActionResult Done()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Token()
        {
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