using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataTrain
{
    public class TeamsAdd
    {
        public static void AddNewTeams(SqlConnection connection)
        {
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
        }
    }
}
