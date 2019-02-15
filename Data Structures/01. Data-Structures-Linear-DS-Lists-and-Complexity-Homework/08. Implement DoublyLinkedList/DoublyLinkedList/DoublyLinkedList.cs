using System;
using System.Collections;
using System.Collections.Generic;

public class DoublyLinkedList<T> : IEnumerable<T>
{
    public class ListNode<T>
    {
        public ListNode(T value)
        {
            this.Value = value;
        }

        public ListNode<T> Next { get; set; }

        public ListNode<T> Previous { get; set; }

        public T Value { get; set; }
    }

    private ListNode<T> head;
    private ListNode<T> tail;

    public int Count { get; private set; }

    public void AddFirst(T element)
    {
        var newNode = new ListNode<T>(element);

        if (this.Count == 0)
        {
            this.head = this.tail = newNode;
        }
        else
        {
            newNode.Next = this.head;
            this.head.Previous = newNode;
            this.head = newNode;
        }

        this.Count++;
    }

    public void AddLast(T element)
    {
        var newNode = new ListNode<T>(element);

        if (this.Count == 0)
        {
            this.head = this.tail = newNode;
        }
        else
        {
            newNode.Previous = this.tail;
            this.tail.Next = newNode;
            this.tail = newNode;
        }

        this.Count++;
    }

    public T RemoveFirst()
    {
        IFRemoveAndCountIsZeroTrhowExc();

        var element = this.head.Value;
        if (this.Count == 1)
        {
            this.head = this.tail = null;
        }
        else
        {
            this.head = this.head.Next;
        }

        this.Count--;

        return element;
    }

    public T RemoveLast()
    {
        IFRemoveAndCountIsZeroTrhowExc();

        var element = this.tail.Value;

        if (this.Count == 1)
        {
            this.head = this.tail = null;
        }
        else
        {
            this.tail = this.tail.Previous;
            this.tail.Next = null;
        }

        this.Count--;

        return element;
    }

    public void ForEach(Action<T> action)
    {
        foreach (var item in this)
        {
            action(item);
        }
    }

    private void IFRemoveAndCountIsZeroTrhowExc()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        var list = this.head;

        while (list != null)
        {
            yield return list.Value;

            list = list.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public T[] ToArray()
    {
        var arr = new T[this.Count];
        var index = 0;

        foreach (var item in this)
        {
            arr[index] = item;

            index++;
        }

        return arr;
    }
}


class Example
{
    static void Main()
    {
        var list = new DoublyLinkedList<int>();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.AddLast(5);
        list.AddFirst(3);
        list.AddFirst(2);
        list.AddLast(10);
        Console.WriteLine("Count = {0}", list.Count);

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveFirst();
        list.RemoveLast();
        list.RemoveFirst();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");

        list.RemoveLast();

        list.ForEach(Console.WriteLine);
        Console.WriteLine("--------------------");
    }
}
