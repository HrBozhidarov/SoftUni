using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Distance_in_Labyrinth
{
    class Program
    {
        static void Main(string[] args)
        {
            var size = int.Parse(Console.ReadLine());
            var labyrinth = new int[size, size];

            var position = FufillMatrixReturnInitialPosition(labyrinth, size).Split().Select(int.Parse).ToArray();

            var startRowPosition = position[0];
            var startColPosition = position[1];

            var queue = new Queue<Cell>();
            queue.Enqueue(new Cell(startRowPosition, startColPosition, labyrinth[startRowPosition, startColPosition]));

            while (queue.Count > 0)
            {
                var currentCell = queue.Dequeue();
                var asignValue = currentCell.Value == -2 ? 1 : currentCell.Value + 1;

                //left 
                if (currentCell.Col - 1 >= 0 && labyrinth[currentCell.Row, currentCell.Col - 1] == 0)
                {
                    queue.Enqueue(new Cell(currentCell.Row, currentCell.Col - 1, asignValue));
                    labyrinth[currentCell.Row, currentCell.Col - 1] = asignValue;
                }

                //right 
                if (currentCell.Col + 1 < size && labyrinth[currentCell.Row, currentCell.Col + 1] == 0)
                {
                    queue.Enqueue(new Cell(currentCell.Row, currentCell.Col + 1, asignValue));
                    labyrinth[currentCell.Row, currentCell.Col + 1] = asignValue;
                }

                //up
                if (currentCell.Row - 1 >= 0 && labyrinth[currentCell.Row - 1, currentCell.Col] == 0)
                {
                    queue.Enqueue(new Cell(currentCell.Row - 1, currentCell.Col, asignValue));
                    labyrinth[currentCell.Row - 1, currentCell.Col] = asignValue;
                }

                //down
                if (currentCell.Row + 1 < size && labyrinth[currentCell.Row + 1, currentCell.Col] == 0)
                {
                    queue.Enqueue(new Cell(currentCell.Row + 1, currentCell.Col, asignValue));
                    labyrinth[currentCell.Row + 1, currentCell.Col] = asignValue;
                }
            }

            Print(labyrinth, size);
        }

        private static void Print(int[,] labyrinth, int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (labyrinth[i,j] == -2)
                    {
                        Console.Write('*');
                    }
                    else if (labyrinth[i, j] == -1)
                    {
                        Console.Write('x');
                    }
                    else if (labyrinth[i, j] == 0)
                    {
                        Console.Write('u');
                    }
                    else
                    {
                        Console.Write(labyrinth[i,j]);
                    }
                }

                Console.WriteLine();
            }
        }

        private static string FufillMatrixReturnInitialPosition(int[,] labyrinth, int size)
        {
            var startRowPosition = 0;
            var startColPosition = 0;

            for (int i = 0; i < size; i++)
            {
                var line = Console.ReadLine().ToCharArray().Where(x => x != ' ').ToArray();

                for (int j = 0; j < size; j++)
                {
                    if (line[j] == '*')
                    {
                        startRowPosition = i;
                        startColPosition = j;

                        labyrinth[i, j] = -2;
                    }
                    else if (line[j] == 'x')
                    {
                        labyrinth[i, j] = -1;
                    }
                    else
                    {
                        labyrinth[i, j] = 0;
                    }
                }
            }

            return $"{startRowPosition} {startColPosition}";
        }
    }

    class Cell
    {
        public Cell(int row, int col, int value)
        {
            this.Row = row;
            this.Col = col;
            this.Value = value;
        }

        public int Row { get; private set; }

        public int Col { get; private set; }

        public int Value { get; private set; }
    }
}
