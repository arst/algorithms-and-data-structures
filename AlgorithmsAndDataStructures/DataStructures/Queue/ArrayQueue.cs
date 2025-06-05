using System;

namespace AlgorithmsAndDataStructures.DataStructures.Queue;

public class ArrayQueue<T>
{
    private readonly T[] queue;
    private int pointer = -1;

    public ArrayQueue(int initialCapacity = 8)
    {
        queue = new T[initialCapacity];
    }

    public bool IsEmpty => pointer == -1;

    public void Enqueue(T value)
    {
        if (pointer == queue.Length - 1) throw new ArgumentException("Queue is full.");

        pointer++;
        queue[pointer] = value;
    }

    public T Dequeue()
    {
        if (IsEmpty) throw new ArgumentException("Queue is empty");

        var value = queue[0];

        for (var i = 0; i < pointer; i++) queue[i] = queue[i + 1];

        pointer--;

        return value;
    }
}