using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public interface IViewParkSqlDAL
    {
		Parks GetPark(string ParkCode);
		IList<Parks> GetParks();
    }
}