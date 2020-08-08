using System;

namespace AlgorithmsAndDataStructures.DataStructures.Queue
{
    public class ArrayQueue<T>
    {
        private int pointer = -1;
        private readonly T[] queue;

        public ArrayQueue(int initialCapacity = 8)
        {
            queue = new T[initialCapacity];
        }

        public void Enqueue(T value)
        {
            if (pointer == queue.Length - 1)
            {
#pragma warning disable CA1303 // Do not pass literals as localized parameters
                throw new ArgumentException("Queue is full.");
#pragma warning restore CA1303 // Do not pass literals as localized parameters
            }

            pointer++;
            queue[pointer] = value;
        }

        public T Dequeue()
        {
            if (IsEmpty)
            {
#pragma warning disable CA1303 // Do not pass literals as localized parameters
                throw new ArgumentException("Queue is empty");
#pragma warning restore CA1303 // Do not pass literals as localized parameters
            }

            var value = queue[0];

            for (var i = 0; i < pointer; i++)
            {
                queue[i] = queue[i + 1];
            }

            pointer--;

            return value;
        }

        public bool IsEmpty => pointer == -1;
    }
}
