using System;
using System.Collections.Generic;
using System.Threading;

namespace AlgorithmsAndDataStructures.DataStructures.Concurrency
{
    public class SimpleLeakyBucket
    {
        private int refillRate;
        private int maxCapacity;
        private volatile int currentSize;
        private Queue<int> queue;
        private int locked;

        public SimpleLeakyBucket(int bucketSize, int maxCapacity, int refillRate)
        {
            this.refillRate = refillRate;
            this.maxCapacity = maxCapacity;
            currentSize = maxCapacity;
            locked = 0;
            queue = new Queue<int>();
        }

        public void TryEnqueue()
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

        private void Consume()
        {
            while (true)
            {
                if (Interlocked.Exchange(ref locked, 1) == 0)
                {
                    try
                    {
                        
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
