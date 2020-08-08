using System;
using System.Threading;

namespace AlgorithmsAndDataStructures.DataStructures.Concurrency
{
    public class SimpleTokenBucket
    {
        private readonly int tokenBucketSize;
        private volatile int currentTokens;
        private readonly int refillRate;
        private readonly int refillInterval;
        private Timer refiller;
        private int locked;

        public SimpleTokenBucket(int tokenBucketSize, int refillRate, int refillInterval)
        {
            this.tokenBucketSize = tokenBucketSize;
            currentTokens = tokenBucketSize;
            this.refillRate = refillRate;
            this.refillInterval = refillInterval;
            locked = 0;
            refiller = new Timer(Refill, null, Timeout.Infinite, Timeout.Infinite);
            refiller.Change(refillInterval, Timeout.Infinite);
        }

        public bool TrySend(int value)
        {
            while (true)
            {
                if (Interlocked.Exchange(ref locked, 1) == 0)
                {
                    if (currentTokens < value)
                    {
                        Volatile.Write(ref locked, 0);
                        return false;
                    }

                    try
                    {
                        currentTokens -= value;
                        return true;
                    }
                    finally
                    {
                        Volatile.Write(ref locked, 0);
                    }
                }
            }
        }

        private void Refill(object state)
        {
            while (true)
            {
                if (Interlocked.Exchange(ref locked, 1) == 0)
                {
                    try
                    {
                        currentTokens = Math.Min(currentTokens + refillRate, tokenBucketSize);
                        refiller = new Timer(Refill, null, Timeout.Infinite, Timeout.Infinite);
                        refiller.Change(refillInterval, Timeout.Infinite);
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
