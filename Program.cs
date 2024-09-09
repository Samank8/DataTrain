using DataTrain;
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


                Console.WriteLine("Enter 1 if you want to see the team table and Enter 2 for add new team , Enter 3 for delete any team , Enter 4 for update data:");


                int a = Convert.ToInt32(Console.ReadLine());

                while (a > 0)
                {

                    switch (a)
                    {
                        case 1:
                            TeamsDisplay.DisplayTeams(connection);
                            break;

                        case 2:
                            TeamsAdd.AddNewTeams(connection);

                            Console.WriteLine("This is new Teams table :");

                            TeamsDisplay.DisplayTeams(connection);
                            break;

                        case 3:

                            TeamsDisplay.DisplayTeams(connection);

                           TeamsDelete.DeleteTeams(connection);

                            break;


                        case 4:
                            Console.WriteLine("Enter the TeamID of the team you want to update:");
                            TeamsDisplay.DisplayTeams(connection);

                            TeamsUpdate.UpdateTeams(connection);
                            break;



                        default:
                            break;
                    }

                    Console.WriteLine("Enter 0 for exit ,Enter 1 if you want to see the team table and Enter 2 for add new team, Enter 3 for delete any team " +
                        "Enter 4 for update data :");



                    a = Convert.ToInt32(Console.ReadLine());
                }
                connection.Close();
            }

            Console.ReadKey();
        }







    }
}
