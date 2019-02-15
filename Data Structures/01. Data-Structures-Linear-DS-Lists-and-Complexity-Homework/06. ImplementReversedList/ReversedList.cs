using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ReversedList<T> : IEnumerable<T>
{
    private const int InitialCapacity = 2;

    private T[] list;

    public ReversedList()
    {
        this.list = new T[InitialCapacity];
        this.Capacity = InitialCapacity;
    }

    public int Capacity { get; private set; }

    public int Count { get; private set; }

    public T this[int index]
    {
        get
        {
            CheckIfIndexIsCorrectIfNotThrowExc(index);

            return this.list[this.Count - 1 - index];
        }
        set
        {
            CheckIfIndexIsCorrectIfNotThrowExc(index);

            this.list[this.Count - index - 1] = value;
        }
    }

    private void CheckIfIndexIsCorrectIfNotThrowExc(int index)
    {
        if (index < 0 || index >= this.Count)
        {
            throw new ArgumentOutOfRangeException();
        }
    }

    public T RemoveAt(int index)
    {
        CheckIfIndexIsCorrectIfNotThrowExc(index);

        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        var newList = new T[this.Capacity];
        var returnElement = this.list[index];

        this.CopyAllElementsWithouthCurrentIndexElement(newList, index);

        this.list = newList;
        this.Count--;

        return returnElement;
    }

    public void Add(T item)
    {
        if (this.Capacity == this.Count)
        {
            Grow();
        }

        this.list[this.Count] = item;
        this.Count++;
    }

    private void Grow()
    {
        this.Capacity *= 2;

        var newList = new T[this.Capacity];

        CopyAllElements(newList);

        this.list = newList;
    }

    private void CopyAllElementsWithouthCurrentIndexElement(T[] newList, int index)
    {
        var decreaseIndex = this.Count - 2;
        var skipIndex = this.Count - index - 1;

        for (int i = this.Count - 1; i >= 0; i--)
        {
            if (i == skipIndex)
            {
                continue;
            }

            newList[decreaseIndex] = this.list[i];

            decreaseIndex--;
        }
    }

    private void CopyAllElements(T[] newList)
    {
        for (int i = 0; i < this.Count; i++)
        {
            newList[i] = list[i];
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.Count - 1; i >= 0; i--)
        {
            yield return this.list[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}
