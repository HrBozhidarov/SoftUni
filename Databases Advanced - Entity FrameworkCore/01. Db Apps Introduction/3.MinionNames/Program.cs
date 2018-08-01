using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using IntroductionToDBApps;
using System.Linq;

namespace _3.MinionNames
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var id = int.Parse(Console.ReadLine());

            var result = new Dictionary<string, List<string>>();

            SqlConnection connection = new SqlConnection(Configuration.ConncectionDb);
            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand($@"SELECT V.Name AS Vilian, M.Name as MinionName,M.Age FROM Villains AS V
LEFT OUTER JOIN MinionsVillains AS MV ON MV.VillainId=V.Id
LEFT OUTER JOIN Minions AS M ON M.Id=MV.MinionId
WHERE V.Id={id}", connection);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var nameVilian = (string)reader[0];
                        var minionName = reader[1]==null ? string.Empty : reader[1].ToString();
                        var age = reader[2] == null ? string.Empty : reader[2].ToString();

                        if (!result.ContainsKey(nameVilian))
                        {
                            result[nameVilian] = new List<string>();
                        }

                        if (minionName==string.Empty)
                        {
                            continue;
                        }

                        result[nameVilian].Add($"{minionName} {age}");
                    }

                    foreach (var r in result)
                    {
                        Console.WriteLine($"Villain: {r.Key}");
                        var count = 1;

                        if (r.Value.Count > 0)
                        {
                            foreach (var v in r.Value.OrderBy(x => (x.Split()[0])))
                            {
                                Console.WriteLine($"{count}. {v.Split()[0]} {v.Split()[1]}");
                                count++;
                            }
                        }
                        else
                        {
                            Console.WriteLine("(no minions)");
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"No villain with ID {id} exists in the database.");
                }
            }
        }
    }
}
