using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    public class ParksController : Controller
    {
		public IActionResult ViewParks()
		{
			var parkDAL = new ViewParkSqlDAL(@"Data Source=.\sqlexpress;Initial Catalog=NPGeek;Integrated Security=True");
			var parks = parkDAL.GetParks();

			return View(parks);
		}
	}
}