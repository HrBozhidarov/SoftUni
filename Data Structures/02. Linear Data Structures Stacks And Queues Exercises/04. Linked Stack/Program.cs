using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        var stack = new LinkedStack<int>();

        for (int i = 0; i < 10; i++)
        {
            stack.Push(i);
        }

        Console.WriteLine(string.Join(" ", stack.ToArray()));
    }
}

public class LinkedStack<T>
{
    private Node<T> firstNode;

    public int Count { get; private set; }

    public void Push(T element)
    {
        this.firstNode = new Node<T>(element, this.firstNode);

        this.Count++;
    }

    public T Pop()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        var element = this.firstNode.value;

        this.firstNode = this.firstNode.NextNode;

        this.Count--;

        return element;
    }

    public T[] ToArray()
    {
        var arr = new T[this.Count];
        var node = this.firstNode;
        var index = 0;

        while (node != null)
        {
            arr[index] = node.value;
            node = node.NextNode;
            index++;
        }

        return arr;
    }

    private class Node<T>
    {
        public T value;

        public Node(T value, Node<T> nextNode = null)
        {
            this.NextNode = nextNode;
            this.value = value;
        }

        public Node<T> NextNode { get; set; }
    }
}
