using System.Collections.Generic;
using System.Threading;

namespace AlgorithmsAndDataStructures.DataStructures.Concurrency;

public class SimpleNonBlockingQueue
{
    private readonly Queue<int> queue;
    private readonly int size;
    private int currentSize;
    private int locked;

    public SimpleNonBlockingQueue(int size = 8)
    {
        queue = new Queue<int>();
        currentSize = 0;
        this.size = size;
        locked = 0;
    }

    public void Enqueue(int value)
    {
        while (true)
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

    public bool TryDequeue(out int value)
    {
        value = -1;

        while (true)
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