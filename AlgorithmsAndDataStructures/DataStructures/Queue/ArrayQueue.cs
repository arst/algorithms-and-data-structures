using System;

namespace AlgorithmsAndDataStructures.DataStructures.Queue
{
    public class ArrayQueue<T>
    {
        private int pointer = -1;
        private T[] queue;

        public ArrayQueue(int initialCapacity = 8)
        {
            this.queue = new T[initialCapacity];
        }

        public void Enqueue(T value)
        {
            if (pointer == queue.Length - 1)
            {
                throw new ArgumentException("Queue is full.");
            }

            pointer++;
            queue[pointer] = value;
        }

        public T Dequeue()
        {
            if (IsEmpty)
            {
                throw new ArgumentException("Queue is empty");
            }

            var value = queue[0];

            for (int i = 0; i < pointer; i++)
            {
                queue[i] = queue[i + 1];
            }

            pointer--;

            return value;
        }

        public bool IsEmpty => pointer == -1;
    }
}
