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

                    string sql = $"select * from survey_result inner join park on park.parkCode = survey_result.parkCode";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Survey survey = new Survey();
                        survey.Park = Convert.ToString(reader["parkCode"]);
                        survey.SurveyId = Convert.ToString(reader["surveyId"]);
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

        public bool SaveSurvey(Survey survey)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = $"INSERT into survey_result(emailAddress, parkCode, state, activityLevel) VALUES (@emailAddress, @parkCode, @state, @activityLevel);";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@emailAddress", survey.Email);
                    cmd.Parameters.AddWithValue("@parkCode", survey.Park);
                    cmd.Parameters.AddWithValue("@state", survey.State);
                    cmd.Parameters.AddWithValue("@activityLevel", survey.Activity);

                    cmd.ExecuteNonQuery();
                }
            }

            catch (SqlException)
            {
                return false;
            }

            return true;
        }

        



    }
}
