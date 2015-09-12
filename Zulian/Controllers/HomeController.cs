using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zulian.Models;

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

        public ActionResult SeeData()
        {
            return View();
            //TextReader file = new StreamReader(Server.MapPath(path), System.Text.Encoding.UTF8);
            //String str = "<pre>"+file.ReadToEnd()+"</pre>";
            //file.Close();

            //return new ContentResult() { Content = str };
        }

        public JsonResult getJsonData()
        {
            TextReader file = new StreamReader(Server.MapPath(path), System.Text.Encoding.UTF8);
            List<CollectedData> data = new List<CollectedData>();
            while (file.Peek() != -1)
            {
                String line = file.ReadLine();
                String[] fields = line.Split(';');
                data.Add(new CollectedData
                {
                    Researcher = fields[0],
                    Permission = fields[1],
                    ZoneName = fields[2],
                    HowLong = fields[3],
                    lat = Double.Parse(fields[4]),
                    lng = Double.Parse(fields[5]),
                    lefDown = Int16.Parse(fields[6]),
                    leftTop = Int16.Parse(fields[7]),
                    rightTop = Int16.Parse(fields[8]),
                    rightDown = Int16.Parse(fields[9])
                });
            }
            file.Close();

            return Json(JsonConvert.SerializeObject(data), JsonRequestBehavior.AllowGet);
        }

        public ContentResult SeeData2()
        {
            TextReader file = new StreamReader(Server.MapPath(path), System.Text.Encoding.UTF8);
            String str = "<pre>" + file.ReadToEnd() + "</pre>";
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