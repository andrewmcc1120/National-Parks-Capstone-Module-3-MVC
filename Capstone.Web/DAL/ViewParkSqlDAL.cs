using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
	public class ViewParkSqlDAL : IViewParkSqlDAL
	{
		private readonly string connectionString;

		public ViewParkSqlDAL(string connectionString)
		{
			this.connectionString = connectionString;
		}

		/// <summary>
		/// This gets all of the parks from the NPGeek DB
		/// </summary>
		/// <param name="ParkCode"></param>
		/// <returns></returns>
		public IList<Parks> GetParks()
		{
			IList<Parks> output = new List<Parks>();

			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();

					string sql = $"SELECT * FROM park;";
					SqlCommand cmd = new SqlCommand(sql, conn);

					SqlDataReader reader = cmd.ExecuteReader();

					while (reader.Read())
					{
						Parks park = new Parks();
						park.ParkCode = Convert.ToString(reader["parkCode"]);
						park.Name = Convert.ToString(reader["parkName"]);
						park.State = Convert.ToString(reader["state"]);
						park.Acreage = Convert.ToInt32(reader["acreage"]);
						park.Elevation = Convert.ToInt32(reader["elevationInFeet"]);
						park.MilesOfTrails = Convert.ToInt32(reader["milesOfTrail"]);
						park.NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]);
						park.Climate = Convert.ToString(reader["climate"]);
						park.YearFounded = Convert.ToInt32(reader["yearFounded"]);
						park.AnnualVisitors = Convert.ToInt32(reader["annualVisitorCount"]);
						park.Quote = Convert.ToString(reader["inspirationalQuote"]);
						park.QuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
						park.Description = Convert.ToString(reader["parkDescription"]);
						park.EntryFee = Convert.ToDecimal(reader["entryFee"]);
						park.NumberOfSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);

						output.Add(park);
					}
				}
			}
			catch (SqlException)
			{
				throw;
			}

			return output;
		}

		/// <summary>
		/// Gets a single park from the NPGeek DB
		/// </summary>
		/// <param name="ParkCode"></param>
		/// <returns></returns>
		public Parks GetPark(string ParkCode)
		{
			return GetParks().FirstOrDefault(p => p.ParkCode == ParkCode);
		}
	}
}