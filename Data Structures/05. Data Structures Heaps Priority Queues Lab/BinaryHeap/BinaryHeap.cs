using System;
using System.Collections.Generic;

public class BinaryHeap<T> where T : IComparable<T>
{
    private List<T> heap;

    public BinaryHeap()
    {
        this.heap = new List<T>();
    }

    public int Count
    {
        get
        {
            return this.heap.Count;
        }
    }

    public void Insert(T item)
    {
        this.heap.Add(item);

        this.HeapifyUp(this.Count - 1);
    }

    private void HeapifyUp(int index)
    {
        var parrentIndex = (index - 1) / 2;

        if (parrentIndex < 0)
        {
            return;
        }

        if (this.heap[index].CompareTo(this.heap[parrentIndex]) > 0)
        {
            Swap(parrentIndex, index);

            HeapifyUp(parrentIndex);
        }
    }

    private void Swap(int parrentIndex, int childIndex)
    {
        var temp = this.heap[parrentIndex];
        this.heap[parrentIndex] = this.heap[childIndex];
        this.heap[childIndex] = temp;
    }

    public T Peek()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        return this.heap[0];
    }

    public T Pull()
    {
        if (this.Count == 0)
        {
            throw new InvalidOperationException();
        }

        var result = this.heap[0];

        Swap(0, this.Count - 1);

        this.heap.RemoveAt(this.Count - 1);

        this.HeapifyDown(0);

        return result;
    }

    private void HeapifyDown(int index)
    {
        var leftIndex = (2 * index) + 1;
        var rightIndex = (2 * index) + 2;

        var compareIndex = GetIndex(leftIndex, rightIndex);

        if (compareIndex > -1)
        {
            if (this.heap[index].CompareTo(this.heap[compareIndex]) < 0)
            {
                Swap(compareIndex, index);

                HeapifyDown(compareIndex);
            }
        }
    }

    private int GetIndex(int leftIndex, int rigthIndex)
    {
        if (leftIndex>=this.Count && rigthIndex >= this.Count)
        {
            return -1;
        }

        if (leftIndex >= this.Count)
        {
            return rigthIndex;
        }
        else if (rigthIndex >= this.Count)
        {
            return leftIndex;
        }

        var result = this.heap[leftIndex].CompareTo(this.heap[rigthIndex]) > 0 ? leftIndex : rigthIndex;

        return result;
    }
}
