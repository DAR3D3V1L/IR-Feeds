using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using feeder.Models;
using System.Web.Script.Serialization;
using System.Net;

namespace feeder.Controllers
{
    public class HistoFeedController : Controller
    {
        // GET: HistoFeed

        public ActionResult Index()
        {
            var Today = new TodaysDate
            {
                TDay = DateTime.Now.Day,
                TMonth = DateTime.Now.ToString("MMMM"),
                TYear = DateTime.Now.Year

            };
            return View(Today);
        }

        [HttpPost]
        public ActionResult GetHistoFeeds(string Day, string Month, string Year) {

            var url = "https://clientapi.gcs-web.com/data/73872e17-9913-4f7d-8204-45fa1b438d57/quotes/lookup/weekof?date=" + Year + "-" + Month + "-" + Day + "&symbol=OMCL";

            var client = new WebClient();
            var content = client.DownloadString(url);
            var serialize = new JavaScriptSerializer();
            var jsonContent = serialize.Deserialize<Object>(content);

            return Json(jsonContent, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetHistoFeedThisWeek()
        {
            var ThisDay = DateTime.Now.Day.ToString().PadLeft(2,'0');
            var ThisMonth = DateTime.Now.Month.ToString().PadLeft(2, '0');
            var ThisYear = DateTime.Now.Year.ToString();

            var url = "https://clientapi.gcs-web.com/data/73872e17-9913-4f7d-8204-45fa1b438d57/quotes/lookup/weekof?date=" + ThisYear + "-" + ThisMonth + "-" + ThisDay + "&symbol=OMCL";

            var client = new WebClient();
            var content = client.DownloadString(url);
            var serialize = new JavaScriptSerializer();
            var jsonContent = serialize.Deserialize<Object>(content);

            return Json(jsonContent, JsonRequestBehavior.AllowGet);
        }
    }
}