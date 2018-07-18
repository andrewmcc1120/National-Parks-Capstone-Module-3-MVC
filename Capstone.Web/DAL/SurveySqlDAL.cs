using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
	public class SurveySqlDAL
	{
		private readonly string connectionString;

		public SurveySqlDAL(string connectionString)
		{
			this.connectionString = connectionString;
		}

        public List<Survey> GetSurveys()
        {
            List<Survey> output = new List<Survey>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = $"select * from survey_result";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Survey survey = new Survey();
                        survey.Park = Convert.ToString(reader["surveyId"]);
                        survey.Email = Convert.ToString(reader["emailAddress"]);
                        survey.State = Convert.ToString(reader["state"]);
                        survey.Activity = Convert.ToString(reader["activityLevel"]);
                    }
                }
            }

            catch(SqlException)
            {
                throw;
            }

            return output;
        }
        



    }
}
