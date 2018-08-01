using IntroductionToDBApps;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace _9.IncreaseAgeStoredProcedure
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var id = int.Parse(Console.ReadLine());

            SqlConnection connection = new SqlConnection(Configuration.ConncectionDb);
            connection.Open();

            using (connection)
            {
                var command = new SqlCommand("EXEC usp_GetOlder @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();

                command = new SqlCommand($"SELECT * FROM Minions WHERE Id = {id}", connection);

                var reader = command.ExecuteReader();

                using (reader)
                {
                    reader.Read();

                    Console.WriteLine($"{(string)reader["Name"]} - {(int)reader["Age"]} years old");
                }
            }
        }
    }
}
