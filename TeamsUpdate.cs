using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataTrain
{
    public class TeamsUpdate
    {

       public static void UpdateTeams(SqlConnection connection)
        {
            int teamId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Select the item you want to update:");
            Console.WriteLine("1. Team Name");
            Console.WriteLine("2. Player Count");
            Console.WriteLine("3. Stadium Name");
            Console.WriteLine("4. Stadium Capacity");
            Console.WriteLine("5. Coach Name");
            Console.WriteLine("6. League");
            Console.WriteLine("7. Title Count");

            int choice = Convert.ToInt32(Console.ReadLine());

            string columnName = "";
            string newValue = "";

            switch (choice)
            {
                case 1:
                    columnName = "TeamName";
                    Console.Write("Enter the new team name: ");
                    newValue = Console.ReadLine();
                    break;
                case 2:
                    columnName = "PlayerCount";
                    Console.Write("Enter the new player count: ");
                    newValue = Console.ReadLine();
                    break;
                case 3:
                    columnName = "StadiumName";
                    Console.Write("Enter the new stadium name: ");
                    newValue = Console.ReadLine();
                    break;
                case 4:
                    columnName = "StadiumCapacity";
                    Console.Write("Enter the new stadium capacity: ");
                    newValue = Console.ReadLine();
                    break;
                case 5:
                    columnName = "CoachName";
                    Console.Write("Enter the new coach name: ");
                    newValue = Console.ReadLine();
                    break;
                case 6:
                    columnName = "League";
                    Console.Write("Enter the new league: ");
                    newValue = Console.ReadLine();
                    break;
                case 7:
                    columnName = "TitleCount";
                    Console.Write("Enter the new title count: ");
                    newValue = Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    connection.Close();
                    return;
            }

            string updateSql = $"UPDATE Teams SET {columnName} = @NewValue WHERE TeamID = @TeamID";

            using (SqlCommand updateCommand = new SqlCommand(updateSql, connection))
            {
                updateCommand.Parameters.AddWithValue("@NewValue", newValue);
                updateCommand.Parameters.AddWithValue("@TeamID", teamId);

                int rowsAffected = updateCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Team updated successfully.");
                }
                else
                {
                    Console.WriteLine("No team found with the provided TeamID.");
                }
            }
        }
    }
}
