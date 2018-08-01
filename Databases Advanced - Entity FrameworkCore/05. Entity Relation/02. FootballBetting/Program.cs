using P03_FootballBetting.Data;
using System;

namespace P03_FootballBetting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var context = new FootballBettingContext();

            using(context)
            {
                context.Database.EnsureDeleted();

                context.Database.EnsureCreated();
            }
        }
    }
}
