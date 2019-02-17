using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        var stack = new ArrayStack<int>();

        for (int i = 0; i < 10; i++)
        {
            stack.Push(i);
        }

        Console.WriteLine(String.Join(" ", stack.ToArray()));
    }
}

class ArrayStack<T>
{
    const int InitialCpacity = 16;

    private T[] elements;

    public ArrayStack(int capacity = InitialCpacity)
    {
        this.elements = new T[capacity];
    }

    public int Count { get; private set; }

    public void Push(T element)
    {
        if (this.Count == this.elements.Length)
        {
            Grow();
        }

        this.elements[this.Count] = element;
        this.Count++;
    }

    public T Pop()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        var element = this.elements[this.Count - 1];
        this.elements[this.Count - 1] = default(T);
        this.Count--;

        return element;
    }

    public T[] ToArray()
    {
        var array = new T[this.Count];
        var index = 0;

        for (int i = this.Count - 1; i >= 0; i--)
        {
            array[index] = this.elements[i];

            index++;
        }

        return array;
    }

    public void Grow()
    {
        var newArr = new T[this.elements.Length * 2];

        CopyAllElements(newArr);

        this.elements = newArr;
    }

    public void CopyAllElements(T[] arr)
    {
        for (int i = 0; i < this.Count; i++)
        {
            arr[i] = this.elements[i];
        }
    }
}