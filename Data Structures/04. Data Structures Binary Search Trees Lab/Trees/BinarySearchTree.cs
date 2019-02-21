using System;
using System.Collections.Generic;

public class BinarySearchTree<T> where T : IComparable<T>
{
    private class Node
    {
        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public Node Left { get; set; }

        public Node Right { get; set; }
    }

    private Node roote;

    public BinarySearchTree()
    {

    }

    private BinarySearchTree(Node root)
    {
        this.Copy(root);
    }

    public void Insert(T value)
    {
        this.roote = Insert(value, this.roote);
    }

    private Node Insert(T value, Node node)
    {
        if (node == null)
        {
            return new Node(value);
        }

        if (node.Value.CompareTo(value) > 0)
        {
            node.Left = Insert(value, node.Left);
        }

        if (node.Value.CompareTo(value) < 0)
        {
            node.Right = Insert(value, node.Right);
        }

        return node;
    }

    public bool Contains(T value)
    {
        var node = this.roote;
        var contains = false;

        while (node != null)
        {
            if (node.Value.CompareTo(value) > 0)
            {
                node = node.Left;
            }
            else if (node.Value.CompareTo(value) < 0)
            {
                node = node.Right;
            }
            else
            {
                contains = true;

                break;
            }
        }

        return contains;
    }


    public void DeleteMin()
    {
        if (this.roote == null)
        {
            return;
        }

        if (this.roote.Left == null && this.roote.Right == null)
        {
            this.roote = null;

            return;
        }

        //if (this.roote.Left == null && this.roote.Right != null)
        //{
        //    this.roote = this.roote.Right;

        //    return;
        //}

        Node parrent = null;
        Node min = this.roote;

        while (min.Left != null)
        {
            parrent = min;
            min = min.Left;
        }

        if (min.Right == null)
        {
            parrent.Left = null;
        }
        else
        {
            parrent.Left = min.Right;
        }
    }

    public BinarySearchTree<T> Search(T item)
    {
        var node = this.roote;

        while (node != null)
        {
            if (node.Value.CompareTo(item) > 0)
            {
                node = node.Left;
            }
            else if (node.Value.CompareTo(item) < 0)
            {
                node = node.Right;
            }
            else
            {
                var tree = new BinarySearchTree<T>(node);

                return tree;
            }
        }

        return null;
    }

    private void Copy(Node node)
    {
        if (node == null)
        {
            return;
        }

        this.Insert(node.Value);
        this.Copy(node.Left);
        this.Copy(node.Right);
    }

    public IEnumerable<T> Range(T startRange, T endRange)
    {
        var list = new List<T>();

        this.Range(startRange, endRange, this.roote, list);

        return list;
    }

    private void Range(T startRange, T endRange, Node node, List<T> list)
    {
        if (node == null)
        {
            return;
        }

        var lowerBoundary = startRange.CompareTo(node.Value);
        var higherBoundary = endRange.CompareTo(node.Value);


        if (lowerBoundary < 0)
        {
            Range(startRange, endRange, node.Left, list);
        }

        if (lowerBoundary <= 0 && higherBoundary >= 0)
        {
            list.Add(node.Value);
        }

        if (higherBoundary > 0)
        {
            Range(startRange, endRange, node.Right, list);
        }
    }

    public void EachInOrder(Action<T> action)
    {
        this.EachInOrder(this.roote, action);
    }

    private void EachInOrder(Node node, Action<T> action)
    {
        if (node == null)
        {
            return;
        }

        if (node.Left != null)
        {
            EachInOrder(node.Left, action);
        }

        action(node.Value);

        if (node.Right != null)
        {
            EachInOrder(node.Right, action);
        }
    }
}

public class Launcher
{
    public static void Main(string[] args)
    {
    }
}
