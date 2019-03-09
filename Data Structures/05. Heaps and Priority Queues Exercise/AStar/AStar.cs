using System;
using System.Collections.Generic;

public class AStar
{
    private char[,] map;

    public AStar(char[,] map)
    {
        this.map = map;
    }

    public static int GetH(Node current, Node goal)
    {
        var deltaX = Math.Abs(current.Col - goal.Col);
        var deltaY = Math.Abs(current.Row - goal.Row);

        return deltaX + deltaY;
    }

    public IEnumerable<Node> GetPath(Node start, Node goal)
    {
        var queue = new PriorityQueue<Node>();
        queue.Enqueue(start);
        var parrent = new Dictionary<Node, Node>();
        parrent[start] = null;
        var cost = new Dictionary<Node, int>();
        cost[start] = 0;

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();

            if (current.Equals(goal))
            {
                break;
            }

            var neighbors = GetNeighbors(current);

            foreach (var neighbor in neighbors)
            {
                var newCost = cost[current] + 1;

                if (!cost.ContainsKey(neighbor) || newCost  < cost[neighbor])
                {
                    cost[neighbor] = newCost;
                    neighbor.F = newCost + GetH(neighbor, goal);
                    queue.Enqueue(neighbor);
                    parrent[neighbor] = current;
                }
            }
        }

        var result = GetPath(parrent, start, goal);

        return result;
    }

    private IEnumerable<Node> GetNeighbors(Node current)
    {
        var nodes = new List<Node>();
        var currentRow = current.Row;
        var currentCol = current.Col;

        AddNodeIfPossible(currentRow + 1, currentCol, nodes);
        AddNodeIfPossible(currentRow - 1, currentCol, nodes);
        AddNodeIfPossible(currentRow, currentCol + 1, nodes);
        AddNodeIfPossible(currentRow, currentCol - 1, nodes);

        return nodes;
    }

    private void AddNodeIfPossible(int row, int col, List<Node> nodes)
    {
        if (InBounds(row, col) && IsPassable(row,col))
        {
            nodes.Add(new Node(row, col));
        }
    }

    private bool IsPassable(int row, int col)
    {
        return map[row, col] != 'W';
    }

    private bool InBounds(int row, int col)
    {
        return row >= 0 && row < map.GetLength(0) && col >= 0 && col < map.GetLength(1);
    }

    private IEnumerable<Node> GetPath(Dictionary<Node, Node> parrent, Node start, Node goal)
    {
        var stack = new Stack<Node>();

        if (!parrent.ContainsKey(goal))
        {
            stack.Push(start);

            return stack;
        }

        var current = goal;

        while (current != null)
        {
            stack.Push(current);
            current = parrent[current];
        }

        return stack;
    }
}

