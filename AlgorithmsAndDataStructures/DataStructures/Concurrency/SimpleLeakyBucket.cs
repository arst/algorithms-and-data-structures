using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace AlgorithmsAndDataStructures.DataStructures.Concurrency
{
    public class SimpleLeakyBucket : IDisposable
    {
        private readonly int outputRate;
        private readonly int leakInterval;
        private readonly int maxBucketSize;
        private int bucketSize;
        private readonly Queue<int> queue;
        private int locked;
        private Timer leaker;
        private bool disposed;

        public SimpleLeakyBucket(int maxBucketSize, int outputRate, int leakInterval)
        {
            this.outputRate = outputRate;
            this.leakInterval = leakInterval;
            this.maxBucketSize = maxBucketSize;
            bucketSize = 0;
            locked = 0;
            queue = new Queue<int>();
            leaker = new Timer(Leak, null, Timeout.Infinite, Timeout.Infinite);
            leaker.Change(leakInterval, Timeout.Infinite);
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
                    try
                    {
                        while (queue.Any() && queue.Peek() <= outputRate)
                        {
                            var output = queue.Dequeue();
                            
                            bucketSize -= output;
                        }

                        leaker = new Timer(Leak, null, Timeout.Infinite, Timeout.Infinite);
                        leaker.Change(leakInterval, Timeout.Infinite);
                        return;
                    }
                    finally
                    {
                        Volatile.Write(ref locked, 0);
                    }
                }
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if(disposed)
            {
                return;
            }

            if (disposing)
            {
                leaker.Dispose();
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
