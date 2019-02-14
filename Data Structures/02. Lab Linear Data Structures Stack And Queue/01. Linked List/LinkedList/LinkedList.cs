using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
    public class Node
    {
        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public Node Next { get; set; }
    }

    public Node Head { get; set; }

    public Node Tail { get; set; }

    public int Count { get; private set; }

    public void AddFirst(T item)
    {
        Node old = this.Head;

        this.Head = new Node(item);
        this.Head.Next = old;

        if (this.Count == 0)
        {
            this.Tail = this.Head;
        }

        this.Count++;
    }

    public void AddLast(T item)
    {
        Node old = this.Tail;
        this.Tail = new Node(item);

        if (this.Count == 0)
        {
            this.Head = this.Tail;
        }
        else
        {
            old.Next = this.Tail;
        }

        this.Count++;
    }

    public T RemoveFirst()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        var value = this.Head.Value;
        var afterFirst = this.Head.Next;
        this.Head = afterFirst;

        this.Count--;

        return value;
    }

    public T RemoveLast()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        T value = this.Tail.Value;

        if (this.Count == 1)
        {
            value = this.Head.Value;
            this.Head = null;
            this.Tail = this.Head;
        }
        else
        {
            RemoveLastElementFromTail();
        }

        this.Count--;

        return value;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var node = this.Head;

        while (node != null)
        {
            yield return node.Value;
            node = node.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private void RemoveLastElementFromTail()
    {
        Node parent = this.Head;

        while (parent.Next != this.Tail)
        {
            parent = parent.Next;

        }

        parent.Next = null;
        this.Tail = parent;
    }
}
