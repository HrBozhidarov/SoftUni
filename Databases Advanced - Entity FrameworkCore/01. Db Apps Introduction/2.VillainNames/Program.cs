using System;
using System.Data.SqlClient;
using IntroductionToDBApps;

namespace _2.VillainNames
{
    public class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(Configuration.ConncectionDb);
            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand(@"SELECT V.Name, COUNT(*) AS CountOfMinions FROM Villains AS V
JOIN MinionsVillains AS MV ON MV.VillainId=V.Id
JOIN Minions AS M ON M.Id=MV.MinionId
GROUP BY V.Name
HAVING COUNT(*) > 3
ORDER BY COUNT(*) DESC", connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var name = (string)reader["Name"];

                    var count = (int)reader["CountOfMinions"];

                    Console.WriteLine($"{name} -> {count}");
                }
            }
        }
    }
}
