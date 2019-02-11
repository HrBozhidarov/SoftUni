using System;

public class ArrayList<T>
{
    private const string IndexOutOfRangeMessage = "Index out of range exception.";
    private const int InitialCapacity = 2;

    private T[] innerArray;
    private int capacity;

    public ArrayList(int capacity = InitialCapacity)
    {
        this.innerArray = new T[capacity];
        this.capacity = capacity;
    }

    public int Count { get; private set; }

    public T this[int index]
    {
        get
        {
            IndexOutOfRange(index);

            return this.innerArray[index];
        }

        set
        {
            IndexOutOfRange(index);

            this.innerArray[index] = value;
        }
    }

    public void Add(T item)
    {
        ResizeIfNeeded();

        this.innerArray[Count] = item;

        this.Count++;
    }

    public T RemoveAt(int index)
    {
        IndexOutOfRange(index);

        var returnElement = this.innerArray[index];
        var newArr = new T[this.capacity];
        var isFoundIndex = false;

        for (int i = 0; i < this.Count; i++)
        {
            if (i == index)
            {
                isFoundIndex = true;

                continue;
            }

            if (isFoundIndex)
            {
                newArr[i - 1] = innerArray[i];
            }
            else
            {
                newArr[i] = innerArray[i];
            }
        }

        this.innerArray = newArr;
        this.Count--;

        return returnElement;
    }

    private void ResizeIfNeeded()
    {
        if (this.Count == this.capacity)
        {
            this.capacity *= InitialCapacity;
            var newArray = new T[capacity];

            for (int i = 0; i < this.innerArray.Length; i++)
            {
                newArray[i] = this.innerArray[i];
            }

            this.innerArray = newArray;
        }
    }

    private void IndexOutOfRange(int index)
    {
        if (this.Count < index || index < 0)
        {
            throw new ArgumentOutOfRangeException(IndexOutOfRangeMessage);
        }
    }
}
