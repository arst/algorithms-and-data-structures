using System;
using System.Threading;

namespace AlgorithmsAndDataStructures.DataStructures.Concurrency;

public class SimpleTokenBucket : IDisposable
{
    private readonly int refillInterval;
    private readonly int refillRate;
    private readonly int tokenBucketSize;
    private volatile int currentTokens;
    private bool disposed;
    private int locked;
    private Timer refiller;

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

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public bool TrySend(int value)
    {
        while (true)
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

    private void Refill(object state)
    {
        while (true)
            if (Interlocked.Exchange(ref locked, 1) == 0)
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

    protected virtual void Dispose(bool disposing)
    {
        if (disposed) return;

        if (disposing) refiller.Dispose();

        disposed = true;
    }
}