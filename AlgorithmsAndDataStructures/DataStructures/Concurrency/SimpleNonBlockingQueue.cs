using System.Collections.Generic;
using System.Threading;

namespace AlgorithmsAndDataStructures.DataStructures.Concurrency
{
    public class SimpleNonBlockingQueue
    {
        private int size;
        private Queue<int> queue;
        private int currentSize;
        private int locked;

        public SimpleNonBlockingQueue(int size = 8)
        {
            this.queue = new Queue<int>();
            this.currentSize = 0;
            this.size = size;
            this.locked = 0;
        }

        public void Enqueue(int value)
        {
            while (true)
            {
                if (Interlocked.Exchange(ref locked, 1) == 0)
                {
                    if (currentSize >= size)
                    {
                        Volatile.Write(ref locked, 0);
                        continue;
                    }

                    try
                    {
                        queue.Enqueue(value);
                        currentSize++;
                        return;
                    }
                    finally
                    {
                        Volatile.Write(ref locked, 0);
                    }   
                }
            }
        }

        public bool TryDequeue(out int value)
        {
            value = -1;

            while (true)
            {
                if (Interlocked.Exchange(ref locked, 1) == 0)
                {
                    if (currentSize <= 0)
                    {
                        Volatile.Write(ref locked, 0);
                        return false;
                    }

                    try
                    {
                        value = queue.Dequeue();
                        currentSize--;
                    }
                    finally
                    {
                        Volatile.Write(ref locked, 0);
                    }
                }
            }
        }
    }
}
