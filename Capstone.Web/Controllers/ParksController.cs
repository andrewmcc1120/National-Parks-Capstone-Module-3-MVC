using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    public class ParksController : Controller
    {
		ViewParkSqlDAL dal = new ViewParkSqlDAL(@"Data Source=.\sqlexpress;Initial Catalog=NPGeek;Integrated Security=True");

		public IActionResult ViewParks(AllParksModel allParks)
		{
			var parks = dal.GetParks();
			allParks.Parks = parks;

			return View(allParks);
		}

		public IActionResult Detail(string id)
		{
			var park = dal.GetPark(id);

			return View(park);
		}
	}
}