using System;
using System.Threading;

namespace AlgorithmsAndDataStructures.DataStructures.Concurrency
{
    public class SimpleTokenBucket
    {
        private int tokenBucketSize;
        private volatile int currentTokens;
        private int refillRate;
        private Timer refiller;
        private int locked;

        public SimpleTokenBucket(int tokenBucketSize, int refillRate)
        {
            this.tokenBucketSize = tokenBucketSize;
            this.currentTokens = 0;
            this.refillRate = refillRate;
            locked = 0;
            refiller = new Timer(Refill, null, Timeout.Infinite, Timeout.Infinite);
            refiller.Change(15, Timeout.Infinite);
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
                        currentTokens = Math.Max(currentTokens + refillRate, tokenBucketSize);
                        refiller = new Timer(Refill, null, Timeout.Infinite, Timeout.Infinite);
                        refiller.Change(15, Timeout.Infinite);
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
