using System;
using System.Collections.Generic;

namespace _02._Tron_Racers
{
    class Program
    {
        public interface IPlayer
        {
            string Name { get; }
            int PlayerCoordinateRow { get; set; }

            int PlayerCoordinateCol { get; set; }
        }

        public class FirstPlayer : IPlayer
        {
            public int PlayerCoordinateRow { get; set; }

            public int PlayerCoordinateCol { get; set; }

            public string Name => "f";
        }

        public class SecondPlayer : IPlayer
        {
            public int PlayerCoordinateRow { get; set; }

            public int PlayerCoordinateCol { get; set; }

            public string Name => "s";
        }

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var matrix = new string[n, n];
            var firstPlayer = new FirstPlayer();
            var secondPlayer = new SecondPlayer();

            for (int i = 0; i < n; i++)
            {
                var row = Console.ReadLine().ToCharArray();

                for (int j = 0; j < row.Length; j++)
                {
                    var currentRow = row[j].ToString();

                    if (currentRow == "f")
                    {
                        firstPlayer.PlayerCoordinateRow = i;
                        firstPlayer.PlayerCoordinateCol = j;
                    }

                    if (currentRow == "s")
                    {
                        secondPlayer.PlayerCoordinateRow = i;
                        secondPlayer.PlayerCoordinateCol = j;
                    }

                    matrix[i, j] = currentRow;
                }
            }

            while (true)
            {
                var commands = Console.ReadLine().Split();
                var fCommand = commands[0];
                var sCommand = commands[1];

                if (PlayerMove(matrix, firstPlayer, fCommand, n))
                {
                    break;
                }

                if (PlayerMove(matrix, secondPlayer, sCommand, n))
                {
                    break;
                }
            }

            Print(matrix);
        }

        private static bool PlayerMove(string[,] matrix, IPlayer player, string command, int n)
        {
            if (command == "down")
            {
                if (player.PlayerCoordinateRow + 1 >= n)
                {
                    player.PlayerCoordinateRow = 0;
                }
                else
                {
                    player.PlayerCoordinateRow += 1;
                }

                return EndOFGame(matrix, player);
            }
            else if (command == "up")
            {
                if (player.PlayerCoordinateRow - 1 < 0)
                {
                    player.PlayerCoordinateRow = n - 1;
                }
                else
                {
                    player.PlayerCoordinateRow -= 1;
                }

                return EndOFGame(matrix, player);
            }
            else if (command == "right")
            {
                if (player.PlayerCoordinateCol + 1 >= n)
                {
                    player.PlayerCoordinateCol = 0;
                }
                else
                {
                    player.PlayerCoordinateCol += 1;
                }

                return EndOFGame(matrix, player);
            }
            else
            {
                if (player.PlayerCoordinateCol - 1 < 0)
                {
                    player.PlayerCoordinateCol = n - 1;
                }
                else
                {
                    player.PlayerCoordinateCol -= 1;
                }

                return EndOFGame(matrix, player);
            }
        }

        private static void Print(string[,] matrix)
        {
            var result = new List<string>();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var currentLine = "";

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    currentLine += matrix[i, j];
                }

                result.Add(currentLine);
            }

            Console.WriteLine(string.Join("\n", result));
        }

        private static bool EndOFGame(string[,] matrix, IPlayer player)
        {
            if (matrix[player.PlayerCoordinateRow, player.PlayerCoordinateCol] == "*")
            {
                matrix[player.PlayerCoordinateRow, player.PlayerCoordinateCol] = player.Name;
            }
            else if (matrix[player.PlayerCoordinateRow, player.PlayerCoordinateCol] != player.Name)
            {
                matrix[player.PlayerCoordinateRow, player.PlayerCoordinateCol] = "x";
                return true;
            }

            return false;
        }
    }
}
