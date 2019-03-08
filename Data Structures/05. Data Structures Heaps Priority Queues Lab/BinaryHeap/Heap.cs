using System;

public static class Heap<T> where T : IComparable<T>
{
    public static void Sort(T[] arr)
    {
        var length = arr.Length;

        for (int i = length / 2; i >= 0; i--)
        {
            HeapifyDown(arr, i, length);
        }

        for (int i = length - 1; i > 0; i--)
        {
            Swap(arr, 0, i);

            HeapifyDown(arr, 0, i);
        }
    }

    private static void HeapifyDown(T[] arr, int parentIndex, int length)
    {
        while (parentIndex < length / 2)
        {
            var childIndex = (parentIndex * 2) + 1;

            if (childIndex + 1 < length && IsGreater(arr, childIndex + 1, childIndex))
            {
                childIndex++;
            }

            if (!IsGreater(arr, childIndex, parentIndex))
            {
                break;
            }

            Swap(arr, childIndex, parentIndex);

            parentIndex = childIndex;
        }
    }

    private static void Swap(T[] arr, int childIndex, int parentIndex)
    {
        var temp = arr[childIndex];
        arr[childIndex] = arr[parentIndex];
        arr[parentIndex] = temp;
    }

    private static bool IsGreater(T[] arr, int parrentIndex, int currentIndex)
    {
        return arr[parrentIndex].CompareTo(arr[currentIndex]) > 0;
    }
}
