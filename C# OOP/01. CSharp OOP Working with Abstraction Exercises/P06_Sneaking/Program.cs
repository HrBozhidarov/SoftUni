using System;

namespace P06_Sneaking
{
    public class Sneaking
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            char[][] room = new char[n][];

            FufillTheRomm(n, room);

            int[] samPosition = new int[2];

            GetPositionOnSam(samPosition, room);

            char[] moves = Console.ReadLine().ToCharArray();

            for (int i = 0; i < moves.Length; i++)
            {
                TransformRoom(room);

                int[] getEnemy = new int[2];

                GetEnemy(getEnemy, samPosition, room);

                if (samPosition[1] < getEnemy[1] && room[getEnemy[0]][getEnemy[1]] == 'd' && getEnemy[0] == samPosition[0])
                {
                    PrintSamOutput(samPosition, room);

                    break;
                }
                else if (getEnemy[1] < samPosition[1] && room[getEnemy[0]][getEnemy[1]] == 'b' && getEnemy[0] == samPosition[0])
                {
                    PrintSamOutput(samPosition, room);

                    break;
                }

                room[samPosition[0]][samPosition[1]] = '.';

                SamMove(moves, samPosition, i);

                room[samPosition[0]][samPosition[1]] = 'S';

                GetEnemy(getEnemy, samPosition, room);

                if (room[getEnemy[0]][getEnemy[1]] == 'N' && samPosition[0] == getEnemy[0])
                {
                    PrintNicoladzeOutput(getEnemy, room);

                    break;
                }
            }
        }

        private static void PrintSamOutput(int[] samPosition, char[][] room)
        {
            room[samPosition[0]][samPosition[1]] = 'X';

            Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");

            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    Console.Write(room[row][col]);
                }

                Console.WriteLine();
            }
        }

        private static void PrintNicoladzeOutput(int[] getEnemy, char[][] room)
        {
            room[getEnemy[0]][getEnemy[1]] = 'X';

            Console.WriteLine("Nikoladze killed!");

            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    Console.Write(room[row][col]);
                }

                Console.WriteLine();
            }
        }

        private static void SamMove(char[] moves, int[] samPosition, int i)
        {
            switch (moves[i])
            {
                case 'U':
                    samPosition[0]--;
                    break;
                case 'D':
                    samPosition[0]++;
                    break;
                case 'L':
                    samPosition[1]--;
                    break;
                case 'R':
                    samPosition[1]++;
                    break;
                default:
                    break;
            }
        }

        private static void GetEnemy(int[] getEnemy, int[] samPosition, char[][] room)
        {
            for (int j = 0; j < room[samPosition[0]].Length; j++)
            {
                if (room[samPosition[0]][j] != '.' && room[samPosition[0]][j] != 'S')
                {
                    getEnemy[0] = samPosition[0];
                    getEnemy[1] = j;
                }
            }
        }

        private static void GetPositionOnSam(int[] samPosition, char[][] room)
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'S')
                    {
                        samPosition[0] = row;
                        samPosition[1] = col;
                    }
                }
            }
        }

        private static void FufillTheRomm(int n, char[][] room)
        {
            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                room[row] = new char[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    room[row][col] = input[col];
                }
            }
        }

        private static void TransformRoom(char[][] room)
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'b')
                    {
                        if (row >= 0 && row < room.Length && col + 1 >= 0 && col + 1 < room[row].Length)
                        {
                            room[row][col] = '.';
                            room[row][col + 1] = 'b';
                            col++;
                        }
                        else
                        {
                            room[row][col] = 'd';
                        }
                    }
                    else if (room[row][col] == 'd')
                    {
                        if (row >= 0 && row < room.Length && col - 1 >= 0 && col - 1 < room[row].Length)
                        {
                            room[row][col] = '.';
                            room[row][col - 1] = 'd';
                        }
                        else
                        {
                            room[row][col] = 'b';
                        }
                    }
                }
            }
        }
    }
}
