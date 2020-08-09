using System;
using System.Collections.Generic;
using System.Threading;

namespace AlgorithmsAndDataStructures.DataStructures.Concurrency
{
    public class AsynchronousToSynchronous
    {
        private class AsyncExecutor
        {
#pragma warning disable HAA0302 // Display class allocation to capture closure
#pragma warning disable CA1822 // Mark members as static
            public void ExecuteAsync(Action callback)
#pragma warning restore CA1822 // Mark members as static
#pragma warning restore HAA0302 // Display class allocation to capture closure
            {
                if (callback is null)
                {
                    return;
                }

#pragma warning disable HAA0301 // Closure Allocation Source
                _ = ThreadPool.QueueUserWorkItem(_ =>
#pragma warning restore HAA0301 // Closure Allocation Source
                {
                    Thread.Sleep(1);
                    callback();
                });
            }
        }

#pragma warning disable CA1822 // Mark members as static
#pragma warning disable HAA0302 // Display class allocation to capture closure
        public void ExecuteSync(Queue<int> queue)
#pragma warning restore HAA0302 // Display class allocation to capture closure
#pragma warning restore CA1822 // Mark members as static
        {
            if (queue is null)
            {
                return;
            }

            var asyncExecutor = new AsyncExecutor();
#pragma warning disable HAA0302 // Display class allocation to capture closure
            using var resetEvent = new AutoResetEvent(false);
#pragma warning restore HAA0302 // Display class allocation to capture closure

#pragma warning disable HAA0301 // Closure Allocation Source
            asyncExecutor.ExecuteAsync(() =>
#pragma warning restore HAA0301 // Closure Allocation Source
            {
                queue.Enqueue(1);
                resetEvent.Set();
            });

            resetEvent.WaitOne();
            queue.Enqueue(2);
        }
    }
}
