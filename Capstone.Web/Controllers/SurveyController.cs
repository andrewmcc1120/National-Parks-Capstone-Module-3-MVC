using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        SurveySqlDAL dal = new SurveySqlDAL(@"Data Source=.\sqlexpress;Initial Catalog=NPGeek;Integrated Security=True");

        public IActionResult Index()
        {
            var surveys = dal.GetSurveys();
            return View(surveys);
        }
        
        [HttpGet]
        public IActionResult Survey()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Favorites (Survey survey)
        {
            if (ModelState.IsValid)
            {
                dal.SaveSurvey(survey);
                //return RedirectToAction("Favorites");
                return View(survey);
            }

            return View();
        }
    }
}