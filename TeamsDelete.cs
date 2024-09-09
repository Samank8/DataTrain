using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataTrain
{
    public class TeamsDelete
    {
      public  static void DeleteTeams(SqlConnection connection)
        {
            Console.Write("Enter the TeamID of the team you want to delete: ");
            int teamIdToDelete = Convert.ToInt32(Console.ReadLine());

            string selectSql = "SELECT * FROM Teams WHERE TeamID = @TeamID";

            using (SqlCommand selectCommand = new SqlCommand(selectSql, connection))
            {
                selectCommand.Parameters.AddWithValue("@TeamID", teamIdToDelete);

                using (SqlDataReader reader = selectCommand.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Console.WriteLine("Team details:");
                        Console.WriteLine($"Team ID: {reader["TeamID"]}");
                        Console.WriteLine($"Team Name: {reader["TeamName"]}");
                        Console.WriteLine($"Player Count: {reader["PlayerCount"]}");
                        Console.WriteLine($"Stadium Capacity: {reader["StadiumCapacity"]}");
                        Console.WriteLine($"Coach Name: {reader["CoachName"]}");
                        Console.WriteLine($"League: {reader["League"]}");
                        Console.WriteLine($"Title Count: {reader["TitleCount"]}");
                    }
                    else
                    {
                        Console.WriteLine("No team found with the provided TeamID.");
                        connection.Close();
                        return;
                    }
                }
            }

            Console.Write("Are you sure you want to delete this team? (yes = 1 / no = 2): ");
            int confirmation = Convert.ToInt32(Console.ReadLine());

            if (confirmation == 1)
            {
                string deleteSql = "DELETE FROM Teams WHERE TeamID = @TeamID";

                using (SqlCommand deleteCommand = new SqlCommand(deleteSql, connection))
                {
                    deleteCommand.Parameters.AddWithValue("@TeamID", teamIdToDelete);
                    int rowsAffected = deleteCommand.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Team deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Error deleting team. Please try again.");
                    }
                }
            }
            else if (confirmation == 2)
            {
                Console.WriteLine("Team deletion cancelled.");
            }
            else
            {
                Console.WriteLine("Error !!");
            }
        }
    }
}
