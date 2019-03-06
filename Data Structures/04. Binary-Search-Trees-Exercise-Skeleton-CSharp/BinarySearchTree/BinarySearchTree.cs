using System;
using System.Collections.Generic;

public class BinarySearchTree<T> : IBinarySearchTree<T>
    where T : IComparable
{
    private Node root;

    private class Node
    {
        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public Node Left { get; set; }

        public Node Right { get; set; }

        public int Count { get; set; }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }

    private BinarySearchTree(Node node)
    {
        this.PreOrderCopy(node);
    }

    public BinarySearchTree()
    {
    }

    private void PreOrderCopy(Node node)
    {
        if (node == null)
        {
            return;
        }

        this.Insert(node.Value);
        this.PreOrderCopy(node.Left);
        this.PreOrderCopy(node.Right);
    }


    public void EachInOrder(Action<T> action)
    {
        this.EachInOrder(this.root, action);
    }

    private void EachInOrder(Node node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        this.EachInOrder(node.Left, action);
        action(node.Value);
        this.EachInOrder(node.Right, action);
    }

    public void Insert(T element)
    {
        this.root = this.Insert(element, this.root);
    }

    private Node Insert(T element, Node node)
    {
        if (node == null)
        {
            node = new Node(element);
        }
        else if (element.CompareTo(node.Value) < 0)
        {
            node.Left = this.Insert(element, node.Left);
        }
        else if (element.CompareTo(node.Value) > 0)
        {
            node.Right = this.Insert(element, node.Right);
        }

        node.Count = 1 + this.Count(node.Left) + this.Count(node.Right);

        return node;
    }

    public bool Contains(T element)
    {
        Node current = this.FindElement(element);

        return current != null;
    }

    public BinarySearchTree<T> Search(T element)
    {
        Node current = this.FindElement(element);

        return new BinarySearchTree<T>(current);
    }

    private Node FindElement(T element)
    {
        Node current = this.root;

        while (current != null)
        {
            if (current.Value.CompareTo(element) > 0)
            {
                current = current.Left;
            }
            else if (current.Value.CompareTo(element) < 0)
            {
                current = current.Right;
            }
            else
            {
                break;
            }
        }

        return current;
    }

    public IEnumerable<T> Range(T startRange, T endRange)
    {
        Queue<T> queue = new Queue<T>();

        this.Range(this.root, queue, startRange, endRange);

        return queue;
    }

    private void Range(Node node, Queue<T> queue, T startRange, T endRange)
    {
        if (node == null)
        {
            return;
        }

        int nodeInLowerRange = startRange.CompareTo(node.Value);
        int nodeInHigherRange = endRange.CompareTo(node.Value);

        if (nodeInLowerRange < 0)
        {
            this.Range(node.Left, queue, startRange, endRange);
        }
        if (nodeInLowerRange <= 0 && nodeInHigherRange >= 0)
        {
            queue.Enqueue(node.Value);
        }
        if (nodeInHigherRange > 0)
        {
            this.Range(node.Right, queue, startRange, endRange);
        }
    }

    public void DeleteMin()
    {
        this.root = this.DeleteMin(this.root);
    }

    private Node DeleteMin(Node node)
    {
        if (node == null)
        {
            throw new InvalidOperationException();
        }

        if (node.Left == null)
        {
            return node.Right;
        }

        node.Left = this.DeleteMin(node.Left);

        node.Count = 1 + this.Count(node.Left) + this.Count(node.Right);

        return node;
    }

    public void Delete(T element)
    {
        if (this.Count(this.root) == 0 || !this.Contains(element))
        {
            throw new InvalidOperationException();
        }

        this.Delete(this.root, element);
    }

    private Node Delete(Node node, T element)
    {
        if (node == null)
        {
            return null;
        }

        var compare = node.Value.CompareTo(element);

        if (compare > 0)
        {
            node.Left = this.Delete(node.Left, element);
        }
        else if (compare < 0)
        {
            node.Right = this.Delete(node.Right, element);
        }
        else
        {
            if (node.Left == null) { return node.Right; }
            if (node.Right == null) { return node.Left; }

            Node leftMost = this.RightSubTreeLeftMostElement(node.Right);

            node.Value = leftMost.Value;

            node.Right = this.Delete(node.Right, leftMost.Value);
        }

        node.Count = 1 + this.Count(node.Left) + this.Count(node.Right);

        return node;
    }

    private Node RightSubTreeLeftMostElement(Node node)
    {
        var current = node;

        while (current.Left != null)
        {
            current = current.Left;
        }

        return current;
    }

    public void DeleteMax()
    {
        this.root = DeleteMax(this.root);
    }

    private Node DeleteMax(Node node)
    {
        if (node == null)
        {
            throw new InvalidOperationException();
        }

        if (node.Right == null)
        {
            return node.Left;
        }

        node.Right = this.DeleteMax(node.Right);

        node.Count = 1 + this.Count(node.Right) + this.Count(node.Left);

        return node;
    }

    public int Count()
    {
        return this.Count(this.root);
    }

    private int Count(Node node)
    {
        if (node == null)
        {
            return 0;
        }

        return node.Count;
    }

    public int Rank(T element)
    {
        var result = this.Rank(element, this.root);
        return result;
    }

    private int Rank(T element, Node node)
    {
        if (node == null)
        {
            return 0;
        }

        var compare = node.Value.CompareTo(element);

        if (compare > 0)
        {
            return this.Rank(element, node.Left);
        }

        if (compare < 0)
        {
            return 1 + this.Count(node.Left) + this.Rank(element, node.Right);
        }

        return this.Count(node.Left);

    }

    public T Select(int rank)
    {
        return this.Select(this.root, rank);
    }

    private T Select(Node node, int rank)
    {
        if (node == null)
        {
            throw new InvalidOperationException();
        }

        var nodeChildren = this.Count(node.Left);

        if (nodeChildren > rank)
        {
            return this.Select(node.Left, rank);
        }

        if (nodeChildren < rank)
        {
            return this.Select(node.Right, rank - nodeChildren - 1);
        }

        return node.Value;
    }

    public T Ceiling(T element)
    {
        if (this.root == null)
        {
            throw new InvalidOperationException();
        }

        return this.Select(this.Rank(element) + 1);
    }

    public T Floor(T element)
    {
        if (this.root == null)
        {
            throw new InvalidOperationException();
        }

        return this.Select(this.Rank(element) - 1);
    }
}

public class Launcher
{
    public static void Main(string[] args)
    {

    }
}