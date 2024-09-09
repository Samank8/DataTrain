using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataTrain
{
    public class TeamsDisplay
    {
        public static void DisplayTeams(SqlConnection connection)
        {
            string SqlTeams = "SELECT * FROM Teams";
            SqlCommand command = new SqlCommand(SqlTeams, connection);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"Team ID: {reader["TeamID"]}, Team Name: {reader["TeamName"]}");
                }
            }
        }
    }
}
