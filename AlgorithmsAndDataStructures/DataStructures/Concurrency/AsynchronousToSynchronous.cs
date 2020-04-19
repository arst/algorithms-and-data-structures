using System;
using System.Collections.Generic;
using System.Threading;

namespace AlgorithmsAndDataStructures.DataStructures.Concurrency
{
    public class AsynchronousToSynchronous
    {
        private class AsyncExecutor
        {
            public void ExecuteAsync(Action callback)
            {
                ThreadPool.QueueUserWorkItem((object _) => {
                    Thread.Sleep(1);
                    callback();
                });
            }
        }

        public void ExecuteSync(Queue<int> queue)
        {
            var asyncExecutor = new AsyncExecutor();
            using var resetEvent = new AutoResetEvent(false);

            asyncExecutor.ExecuteAsync(() => {
                queue.Enqueue(1);
                resetEvent.Set();
            });

            resetEvent.WaitOne();
            queue.Enqueue(2);
        }
    }
}
