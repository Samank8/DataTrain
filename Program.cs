using System;
using System.Data.SqlClient;

namespace DatabaseConnectionTest
{
    class Program
    {
        static void Main(string[] args)
        {

            string connectionString = "Server=DESKTOP-6AENSE5;Database=FootbalTeam;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();


                Console.WriteLine("Enter 1 if you want to see the team table and Enter 2 for add new team , Enter 3 for delete any team:");
                int a = Convert.ToInt32(Console.ReadLine());

                while (a > 0)
                {

                    switch (a)
                    {
                        case 1:
                            string sqlTeams1 = "SELECT * FROM Teams";
                            SqlCommand command1 = new SqlCommand(sqlTeams1, connection);



                            using (SqlDataReader reader = command1.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Console.WriteLine($"Team ID: {reader["TeamID"]}, Team Name: {reader["TeamName"]}");
                                }
                            }
                            break;

                        case 2:
                            Console.Write("enter your team name: ");
                            String TeamName = Console.ReadLine();

                            Console.Write("enter the number of your team players: ");
                            int PlayerCount = int.Parse(Console.ReadLine());

                            Console.Write("enter the stadium name: ");
                            String StadiumName = Console.ReadLine();

                            Console.Write("enter the stadium capacity: ");
                            int StadiumCapacity = int.Parse(Console.ReadLine());

                            Console.Write("enter your team caoch name: ");
                            String CoachName = Console.ReadLine();

                            Console.Write("enter your team league: ");
                            String League = Console.ReadLine();

                            Console.Write("enter the number of title which your team won: ");
                            int TitleCount = int.Parse(Console.ReadLine());


                            string insertSql = "INSERT INTO Teams (TeamName, PlayerCount, StadiumName, StadiumCapacity, CoachName, League, TitleCount) " +
                                             "VALUES (@TeamName, @PlayerCount, @StadiumName, @StadiumCapacity, @CoachName, @League, @TitleCount)";


                            using (SqlCommand insertCommand = new SqlCommand(insertSql, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@TeamName", TeamName);
                                insertCommand.Parameters.AddWithValue("@PlayerCount", PlayerCount);
                                insertCommand.Parameters.AddWithValue("@StadiumName", StadiumName);
                                insertCommand.Parameters.AddWithValue("@StadiumCapacity", StadiumCapacity);
                                insertCommand.Parameters.AddWithValue("@CoachName", CoachName);
                                insertCommand.Parameters.AddWithValue("@League", League);
                                insertCommand.Parameters.AddWithValue("@TitleCount", TitleCount);

                                Console.Write("new Team successfuly added");

                                int rowsAffected = insertCommand.ExecuteNonQuery();
                                Console.WriteLine($"{rowsAffected}");
                            }
                            break;

                        case 3:

                            string sqlTeams2 = "SELECT * FROM Teams";
                            SqlCommand command2 = new SqlCommand(sqlTeams2, connection);



                            using (SqlDataReader reader = command2.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Console.WriteLine($"Team ID: {reader["TeamID"]}, Team Name: {reader["TeamName"]}");
                                }
                            }


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

                            break;

                        default:
                            break;
                    }

                    Console.WriteLine("Enter 0 for exit ,Enter 1 if you want to see the team table and Enter 2 for add new team, Enter 3 for delete any team :");
                    a = Convert.ToInt32(Console.ReadLine());
                }
                connection.Close();
            }

            Console.ReadKey();
        }
    }
}
