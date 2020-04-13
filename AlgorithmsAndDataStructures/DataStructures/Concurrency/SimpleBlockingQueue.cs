using System.Collections.Generic;
using System.Threading;

namespace AlgorithmsAndDataStructures.Algorithms.Concurrency
{
    public class SimpleBlockingQueue
    {
        private int size;
        private Queue<int> queue;
        private int currentSize;
        private object lockObject = new object();

        public SimpleBlockingQueue(int size = 8)
        {
            this.queue = new Queue<int>();
            this.currentSize = 0;
            this.size = size;
        }

        public void Enqueue(int value)
        {
            try
            {
                Monitor.Enter(lockObject);

                while (currentSize >= size)
                {
                    Monitor.Wait(lockObject);
                }

                queue.Enqueue(value);
                currentSize++;
                // Why do we need to call PulseAll instead of Pulse?
                // Consider a situation with two producer threads and one consumer thread all working with a queue of size one. 
                // It's possible that when an item is added to the queue by one of the producer threads, the other two threads are blocked waiting on the condition variable. 
                // If the producer thread after adding an item invokes Pulse() it is possible that the other producer thread is chosen by the system to resume execution. 
                // The woken-up producer thread would find the queue full and go back to waiting on the condition variable, causing a deadlock. 
                // Invoking PulesAll() assures that the consumer thread also gets a chance to wake up and resume execution.
                Monitor.PulseAll(lockObject);
            }
            finally
            {
                Monitor.Exit(lockObject);
            }
        }

        public int Dequeue()
        {
            int dequeued;

            try
            {
                Monitor.Enter(lockObject);
                while (currentSize <= 0)
                {
                    Monitor.Wait(lockObject);
                }

                dequeued = queue.Dequeue();
                currentSize--;
                // Why do we need to call PulseAll instead of Pulse?
                // Consider a situation with two producer threads and one consumer thread all working with a queue of size one. 
                // It's possible that when an item is added to the queue by one of the producer threads, the other two threads are blocked waiting on the condition variable. 
                // If the producer thread after adding an item invokes Pulse() it is possible that the other producer thread is chosen by the system to resume execution. 
                // The woken-up producer thread would find the queue full and go back to waiting on the condition variable, causing a deadlock. 
                // Invoking PulesAll() assures that the consumer thread also gets a chance to wake up and resume execution.
                Monitor.PulseAll(lockObject);
            }
            finally
            {
                Monitor.Exit(lockObject);
            }

            return dequeued;
        }
    }
}
