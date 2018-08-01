using IntroductionToDBApps;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace _8.IncreaseMinionAge
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var ids = Console.ReadLine().Split().Select(int.Parse).ToArray();

            SqlConnection connection = new SqlConnection(Configuration.ConncectionDb);
            connection.Open();

            using (connection)
            {
                for (int i = 0; i < ids.Length; i++)
                {
                    new SqlCommand($@"UPDATE Minions
	SET Name=UPPER(LEFT(Name,1))+SUBSTRING(Name,2,LEN(Name)-1), Age+=1
	WHERE Id={ids[i]}", connection).ExecuteNonQuery();
                }

                SqlDataReader reader = new SqlCommand($@"SELECT CONCAT(name,' ',Age) AS NameAndAge FROM Minions", connection).ExecuteReader();

                while (reader.Read())
                {
                    var currentLine = reader[0].ToString();

                    Console.WriteLine(currentLine);
                }
            }
        }
    }
}
