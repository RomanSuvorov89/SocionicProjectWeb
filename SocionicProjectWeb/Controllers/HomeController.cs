using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SocionicProjectWeb.Models;

namespace SocionicProjectWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Result(int[] groupOfAnswers, int[] arrayAnswers, string currentTime)
        {
            var answerBools = arrayAnswers.Select(i => i != 0).ToArray();
            using (SocionicEngine socionicEngine = new SocionicEngine())
            {
                socionicEngine.SaveToDB(groupOfAnswers, answerBools, currentTime);
            }
            return RedirectToAction("SecretPage");
        }

        public ActionResult SecretPage()
        {
            List<Results> results;
            SocionicEntities db = new SocionicEntities();
            results = db.Results.ToList();
                return View(results);

        }
    }
}