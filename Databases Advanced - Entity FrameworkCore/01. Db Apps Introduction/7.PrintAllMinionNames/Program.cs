using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using IntroductionToDBApps;

namespace _7.PrintAllMinionNames
{
    class StartUp
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(Configuration.ConncectionDb);
            connection.Open();

            using (connection)
            {
                var names = new List<string>();

                SqlCommand command = new SqlCommand($@"SELECT Name FROM Minions", connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var name = (string)reader[0];

                    names.Add(name);
                }

                var result = new List<string>();

                for (int i = 0; i < names.Count/2; i++)
                {
                    result.Add(names[i]);
                    result.Add(names[names.Count - 1 - i]);
                }

                if (names.Count%2==1)
                {
                    result.Add(names[names.Count / 2]);
                }

                foreach (var r in result)
                {
                    Console.WriteLine(r);
                }
            }
        }
    }
}
