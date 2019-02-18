using System;
using System.Collections.Generic;

public class Tree<T>
{
    public Tree(T value, params Tree<T>[] children)
    {
        this.Value = value;
        this.Children = new List<Tree<T>>();

        foreach (var child in children)
        {
            this.Children.Add(child);
        }
    }

    public T Value { get; set; }

    public List<Tree<T>> Children { get; set; }

    public void Print(int indent = 0)
    {
        Console.WriteLine(new string(' ', indent) + this.Value);

        foreach (var child in this.Children)
        {
            child.Print(indent + 2);
        }
    }

    public void Each(Action<T> action)
    {
        action(this.Value);

        foreach (var child in this.Children)
        {
            child.Each(action);
        }
    }

    public IEnumerable<T> OrderDFS()
    {
        var result = new List<T>();

        DFS(this, result);

        return result;
    }

    private void DFS(Tree<T> node,List<T> result)
    {
        foreach (var child in node.Children)
        {
            DFS(child, result);
        }

        result.Add(node.Value);
    }

    public IEnumerable<T> OrderBFS()
    {
        var result = new List<T>();
        var queue = new Queue<Tree<T>>();

        BFS(result, queue);

        return result;
    }

    private void BFS(List<T> result,Queue<Tree<T>> queue)
    {
        queue.Enqueue(this);

        while (queue.Count > 0)
        {
            var currentNode = queue.Dequeue();

            result.Add(currentNode.Value);

            foreach (var child in currentNode.Children)
            {
                queue.Enqueue(child);
            }
        }
    }
}
