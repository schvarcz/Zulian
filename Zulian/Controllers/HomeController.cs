using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Zulian.Controllers
{
    public class HomeController : Controller
    {
        static String fileName = "steinmetz.csv";
        static String path = "~/" + fileName;
        public ActionResult Index()
        {
            return View();
        }
        
        public ContentResult SeeData()
        {
            TextReader file = new StreamReader(Server.MapPath(path), System.Text.Encoding.UTF8);
            String str = "<pre>"+file.ReadToEnd()+"</pre>";
            file.Close();

            return new ContentResult() { Content = str };
        }

        public JsonResult Save()
        {

            String str = "";
            foreach (String key in Request.Form)
            {
                if (str != "")
                    str += ";";
                str += Request.Form.Get(key);
            }
            TextWriter file = new StreamWriter(Server.MapPath(path), true, System.Text.Encoding.UTF8);
            file.WriteLine(str);
            file.Close();
            ViewBag.Message = str;

            return Json(new { Data = str }, JsonRequestBehavior.AllowGet);
        }

        public ContentResult HardReset()
        {
            try
            {
                TextWriter file = new StreamWriter(Server.MapPath(path), false, System.Text.Encoding.UTF8);
                file.Write("");
                file.Close();
            }
            catch (Exception e)
            { }
            return new ContentResult() { Content = "Arquivo resetado" };
        }
    }
}