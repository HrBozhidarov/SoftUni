using IntroductionToDBApps;
using System;
using System.Data.SqlClient;

namespace _6.RemoveVillain
{
    class Program
    {
        static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());

            SqlConnection connection = new SqlConnection(Configuration.ConncectionDb);
            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand("SELECT Id FROM Villains WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                int? result = (int?)command.ExecuteScalar();

                if (result == null)
                {
                    Console.WriteLine("No such villain was found.");
                    connection.Close();
                    return;
                }

                command = new SqlCommand("SELECT COUNT(*) FROM MinionsVillains WHERE VillainId = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                int minionsCount = (int)command.ExecuteScalar();

                command = new SqlCommand("DELETE FROM MinionsVillains WHERE VillainId = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();

                command = new SqlCommand("SELECT Name FROM Villains WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                string villainName = (string)command.ExecuteScalar();

                command = new SqlCommand("DELETE FROM Villains WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();

                Console.WriteLine($"{villainName} was deleted.");
                Console.WriteLine($"{minionsCount} minions were released.");
            }
        }
    }
}
