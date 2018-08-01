using System;
using System.Data.SqlClient;
using System.Linq;
using IntroductionToDBApps;

namespace _4.Add_Minion
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var infoMinion = Console.ReadLine().Split().Skip(1).ToArray();
            var villianName = Console.ReadLine().Split()[1];

            var nameOfMinion = infoMinion[0];
            var age = int.Parse(infoMinion[1]);
            var townName = infoMinion[2];

            SqlConnection connection = new SqlConnection(Configuration.ConncectionDb);
            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand($@"SELECT COUNT(*) FROM Towns
WHERE Name='{townName}'", connection);

                if ((int)(command.ExecuteScalar()) == 0)
                {
                    command = new SqlCommand($@"INSERT INTO Towns(Name) VALUES
('{townName}')", connection);

                    command.ExecuteNonQuery();

                    Console.WriteLine($"Town {townName} was added to the database.");
                }

                command = new SqlCommand($@"SELECT COUNT(*) FROM Villains
WHERE Name='{villianName}'", connection);

                if ((int)command.ExecuteScalar() == 0)
                {
                    command = new SqlCommand($@"INSERT INTO Villains VALUES
('{villianName}',4)",connection);

                    command.ExecuteNonQuery();

                    Console.WriteLine($"Villain {villianName} was added to the database.");
                }

                int townId = (int)new SqlCommand($"SELECT Id FROM Towns WHERE Name = '{townName}'", connection).ExecuteScalar();

                command = new SqlCommand($@"
INSERT INTO  Minions VALUES
('{nameOfMinion}',{age},{townId})",connection);

                command.ExecuteNonQuery();

                int villainId = (int)new SqlCommand($"SELECT Id FROM Villains WHERE Name = '{villianName}'", connection).ExecuteScalar();
                int minionId = (int)new SqlCommand($"SELECT Id FROM Minions WHERE Name = '{nameOfMinion}'", connection).ExecuteScalar();

                command = new SqlCommand($"INSERT INTO MinionsVillains VALUES ({minionId}, {villainId})", connection);
                command.ExecuteNonQuery();
                Console.WriteLine($"Successfully added {nameOfMinion} to be minion of {villianName}.");
            }
        }
    }
}
