using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace AlgorithmsAndDataStructures.DataStructures.Concurrency
{
    public class SimpleLeakyBucket
    {
        private int outputRate;
        private int maxBucketSize;
        private int bucketSize;
        private Queue<int> queue;
        private int locked;
        private Timer leaker;

        public SimpleLeakyBucket(int maxBucketSize, int outputRate, TimeSpan leakInterval)
        {
            this.outputRate = outputRate;
            this.maxBucketSize = maxBucketSize;
            this.bucketSize = this.maxBucketSize;
            locked = 0;
            queue = new Queue<int>();
            this.leaker = new Timer(Leak, null, Timeout.Infinite, Timeout.Infinite);
            leaker.Change(15, Timeout.Infinite);
        }

        public bool TryEnqueue(int value)
        {
            while (true)
            {
                if (Interlocked.Exchange(ref locked, 1) == 0)
                {
                    if (bucketSize +  value > maxBucketSize)
                    {
                        Volatile.Write(ref locked, 0);
                        return false;
                    }

                    try
                    {
                        queue.Enqueue(value);
                        bucketSize += value;
                        return true;
                    }
                    finally
                    {
                        Volatile.Write(ref locked, 0);
                    }
                }
            }
        }

        private void Leak(object state)
        {
            while (true)
            {
                if (Interlocked.Exchange(ref locked, 1) == 0)
                {
                    var remainingRate = outputRate;
                    try
                    {
                        while (queue.Any() && queue.Peek() < outputRate)
                        {
                            var output = queue.Dequeue();
                            
                            bucketSize -= output;
                            remainingRate -= output;
                        }

                        leaker = new Timer(Leak, null, Timeout.Infinite, Timeout.Infinite);
                        leaker.Change(15, Timeout.Infinite);
                        return;
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
