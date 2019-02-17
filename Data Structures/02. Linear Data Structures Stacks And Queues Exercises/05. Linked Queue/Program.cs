using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        var queue = new LinkedQueue<int>();

        for (int i = 0; i < 10; i++)
        {
            queue.Enqueue(i);
        }

        queue.Dequeue();

        Console.WriteLine(string.Join(" ", queue.ToArray()));
    }
}

public class LinkedQueue<T>
{
    public int Count { get; private set; }

    private QueueNode<T> head;
    private QueueNode<T> tail;

    public void Enqueue(T element)
    {
        var queueNode = new QueueNode<T>(element);
        
        if (this.Count == 0)
        {
            head = tail = queueNode;
        }
        else
        {
            var old = this.tail;
            this.tail = queueNode;
            this.tail.PrevNode = old;
            old.NextNode = this.tail;
        }

        this.Count++;
    }

    public T Dequeue()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        var element = this.head.Value;

        this.head = this.head.NextNode;

        this.Count--;

        return element;
    }

    public T[] ToArray()
    {
        var arr = new T[this.Count];
        var currentHead = this.head;
        var index = 0;

        while (currentHead != null)
        {
            arr[index] = currentHead.Value;

            currentHead = currentHead.NextNode;

            index++;
        }

        return arr;
    }

    private class QueueNode<T>
    {
        public QueueNode(T value)
        {
            this.Value = value;
        }

        public T Value { get; private set; }
        public QueueNode<T> NextNode { get; set; }
        public QueueNode<T> PrevNode { get; set; }
    }
}

