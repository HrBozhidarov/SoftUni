using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public class Team
    {
        public Team()
        {
            this.Members = new List<string>();
        }

        public List<string> Members { get; set; }
        public string CreatorName { get; set; }
        public string TeamName { get; set; }
    }

    public static void Main()
    {
        var teams = new List<Team>();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split('-');

            var nameOfCreator = input[0];
            var teamName = input[1];

            if (teams.Any(x => x.TeamName == teamName))
            {
                Console.WriteLine($"Team {teamName} was already created!");
                continue;
            }
            else if (teams.Any(x => x.CreatorName == nameOfCreator))
            {
                Console.WriteLine($"{nameOfCreator} cannot create another team!");
                continue;
            }

            Console.WriteLine($"Team {teamName} has been created by {nameOfCreator}!");
            var team = new Team();
            team.CreatorName = nameOfCreator;
            team.TeamName = teamName;
            teams.Add(team);
        }

        var commandFroMembers = "";

        while ((commandFroMembers = Console.ReadLine()) != "end of assignment")
        {
            var separateCommands = commandFroMembers.Split(new char[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
            var user = separateCommands[0];
            var teamName = separateCommands[1];

            if (teams.All(x => x.TeamName != teamName))
            {
                Console.WriteLine($"Team {teamName} does not exist!");
                continue;
            }

            if (teams.Any(x => x.Members.Contains(user)) || teams.Any(x => x.CreatorName == user))
            {
                Console.WriteLine($"Member {user} cannot join team {teamName}!");
                continue;
            }

            int index = teams.FindIndex(x => x.TeamName == teamName);
            teams[index].Members.Add(user);
        }

        foreach (var currentTeam in teams.OrderByDescending(x => x.Members.Count).ThenBy(x => x.TeamName).ToList())
        {
            if (currentTeam.Members.Count != 0)
            {
                Console.WriteLine("{0}", currentTeam.TeamName);
                Console.WriteLine("- {0}", currentTeam.CreatorName);
                foreach (string currentUser in currentTeam.Members.OrderBy(x => x))
                {
                    Console.WriteLine("-- {0}", currentUser);
                }
            }
        }

        Console.WriteLine("Teams to disband:");
        foreach (var currentTeam in teams.OrderBy(x => x.TeamName))
        {
            if (currentTeam.Members.Count == 0)
                Console.WriteLine("{0}", currentTeam.TeamName);
        }
    }
}