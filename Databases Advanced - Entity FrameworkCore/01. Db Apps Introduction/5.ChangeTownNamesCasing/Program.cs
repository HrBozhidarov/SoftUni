using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using IntroductionToDBApps;

namespace _5.ChangeTownNamesCasing
{
    class Program
    {
        static void Main(string[] args)
        {
            var country = Console.ReadLine();

            SqlConnection connection = new SqlConnection(Configuration.ConncectionDb);
            connection.Open();

            using (connection)
            {
                SqlCommand command = new SqlCommand($@"SELECT Id FROM Countries
WHERE Name='{country}'", connection);

                int? countryId = (int?)command.ExecuteScalar();

                if (countryId == null ||(int)new SqlCommand($@"SELECT COUNT(*) FROM Towns 
where CountryCode ={countryId}",connection).ExecuteScalar()==0)
                {
                    Console.WriteLine("No town names were affected.");
                }
                else
                {
                    command = new SqlCommand($@"UPDATE Towns
	SET Name=UPPER(Name)
	WHERE CountryCode={countryId}", connection);

                    command.ExecuteNonQuery();

                    var rowAffected = (int)new SqlCommand($"SELECT COUNT(*) FROM Towns WHERE CountryCode={countryId}", connection).ExecuteScalar();

                    command = new SqlCommand($@"SELECT Name FROM Towns WHERE CountryCode={countryId}", connection);

                    SqlDataReader reader = command.ExecuteReader();

                    var townNames = new List<string>();

                    while (reader.Read())
                    {
                        string currentTownName = (string)reader["Name"];

                        townNames.Add(currentTownName);
                    }

                    Console.WriteLine($"{rowAffected} town names were affected");
                    Console.WriteLine($"[{string.Join(", ", townNames)}]");
                }
            }
        }
    }
}
