using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
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
        public async Task<ActionResult> Result(ResultModel objectResult)
        {
	        string type;
	        using (var dbSaveContext = new DBSaveContext())
	        {
		        type = await dbSaveContext.SaveToDB(objectResult);
	        }
	        return RedirectToAction("TypeResult", "Type", new { @myType = type });
        }


        public ActionResult ResultPage()
        {
            return View();
        }

		[HttpGet]
	    public ActionResult ResultTable()
		{
			SocionicEntities db = new SocionicEntities();
		    return PartialView("~/Views/Home/Result/ResultTable.cshtml",db.Results.ToList());
		}

	    [HttpGet]
	    public ActionResult ResultAnswers(int id)
	    {
		    var db = new SocionicEntities();
			ResultAnswers resultAnswers = new ResultAnswers(db.AnswerTable.First(x => x.id == id));
			return PartialView("~/Views/Home/Result/ResultAnswers.cshtml", resultAnswers);
	    }
	}
}