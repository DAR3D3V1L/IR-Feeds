using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Web.Script.Serialization;

namespace feeder.Controllers
{
    public class SecFillingController : Controller
    {
        // GET: SecFilling
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetSecFilings()
        {

            var url = "https://clientapi.gcs-web.com/data/73872e17-9913-4f7d-8204-45fa1b438d57/filings";

            var client = new WebClient();
            var content = client.DownloadString(url);
            var serialize = new JavaScriptSerializer();
            var jsonContent = serialize.Deserialize<Object>(content);

            return Json(jsonContent, JsonRequestBehavior.AllowGet);
        }
    }
}