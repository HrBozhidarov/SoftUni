using System;
using System.Data.SqlClient;

namespace IntroductionToDBApps
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(Configuration.Conncection);
            connection.Open();

            using (connection)
            {
                DoCommand(new SqlCommand("CREATE DATABASE MinionsDB", connection));

                connection.ChangeDatabase("MinionsDB");

                DoCommand(new SqlCommand("CREATE TABLE Countries (Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50))", connection));

                DoCommand(new SqlCommand("CREATE TABLE Towns(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50), CountryCode INT FOREIGN KEY REFERENCES Countries(Id))", connection));

                DoCommand(new SqlCommand("CREATE TABLE Minions(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(30), Age INT, TownId INT FOREIGN KEY REFERENCES Towns(Id))", connection));

                DoCommand(new SqlCommand("CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50))", connection));

                DoCommand(new SqlCommand("CREATE TABLE Villains (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id))", connection));

                DoCommand(new SqlCommand("CREATE TABLE MinionsVillains (MinionId INT FOREIGN KEY REFERENCES Minions(Id),VillainId INT FOREIGN KEY REFERENCES Villains(Id),CONSTRAINT PK_MinionsVillains PRIMARY KEY (MinionId, VillainId))", connection));

                DoCommand(new SqlCommand("INSERT INTO Countries ([Name]) VALUES ('Bulgaria'),('England'),('Cyprus'),('Germany'),('Norway')", connection));


                DoCommand(new SqlCommand("INSERT INTO Towns ([Name], CountryCode) VALUES ('Plovdiv', 1),('Varna', 1),('Burgas', 1),('Sofia', 1),('London', 2),('Southampton', 2),('Bath', 2),('Liverpool', 2),('Berlin', 3),('Frankfurt', 3),('Oslo', 4)", connection));

                DoCommand(new SqlCommand("INSERT INTO Minions (Name,Age, TownId) VALUES('Bob', 42, 3),('Kevin', 1, 1),('Bob ', 32, 6),('Simon', 45, 3),('Cathleen', 11, 2),('Carry ', 50, 10),('Becky', 125, 5),('Mars', 21, 1),('Misho', 5, 10),('Zoe', 125, 5),('Json', 21, 1)", connection));

                DoCommand(new SqlCommand("INSERT INTO EvilnessFactors (Name) VALUES ('Super good'),('Good'),('Bad'), ('Evil'),('Super evil')", connection));

                DoCommand(new SqlCommand("INSERT INTO Villains (Name, EvilnessFactorId) VALUES ('Gru',2),('Victor',1),('Jilly',3),('Miro',4),('Rosen',5),('Dimityr',1),('Dobromir',2)", connection));

                DoCommand(new SqlCommand("INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (4,2),(1,1),(5,7),(3,5),(2,6),(11,5),(8,4),(9,7),(7,1),(1,3),(7,3),(5,3),(4,3),(1,2),(2,1),(2,7)", connection));

            }

        }

        public static void DoCommand(SqlCommand command)
        {
            int n = command.ExecuteNonQuery();
        }
    }
}
