using AlgorithmsAndDataStructures.Algorithms.Concurrency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.Concurrency
{
    public class SimpleBlockingQueueTests
    {
        [Fact]
        public async Task Baseline()
        {
            var sut = new SimpleBlockingQueue();
            var queue1 = new Queue<int>();
            var queue2 = new Queue<int>();
            var testSize = 1000000;
            var taskDelay = Task.Delay(TimeSpan.FromSeconds(60));
            using var cancelationTokenSource = new CancellationTokenSource();

            var writerTask = new Task(() => Write());
            var readerTask1 = new Task(() => Read(1, cancelationTokenSource.Token));
            var readerTask2 = new Task(() => Read(2, cancelationTokenSource.Token));
            readerTask1.Start();
            writerTask.Start();
            readerTask2.Start();

            void Write()
            {
                for (int i = 0; i < testSize; i++)
                {
                    sut.Enqueue(i);
                }
            }

            void Read(int queueNumbe, CancellationToken cancellationToken)
            {
                var currentQueue = queueNumbe == 1 ? queue1 : queue2;

                while (currentQueue.Count != testSize)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        throw new OperationCanceledException();
                    }

                    currentQueue.Enqueue(sut.Dequeue());
                }
            }

            await Task.WhenAny(writerTask, taskDelay).ConfigureAwait(false);
            cancelationTokenSource.Cancel();

            Assert.True(queue1.Distinct().Count() == queue1.Count);

            while (queue1.Count > 0)
            {
                var smallerDequeued = queue1.TryDequeue(out int smaller);
                var biggerDequeued = queue1.TryDequeue(out int bigger);

                if (smallerDequeued && biggerDequeued)
                {
                    Assert.True(smaller < bigger);
                }
                
            }

            Assert.True(queue2.Distinct().Count() == queue2.Count);

            while (queue2.Count > 0)
            {
                var smallerDequeued = queue2.TryDequeue(out int smaller);
                var biggerDequeued = queue2.TryDequeue(out int bigger);

                if (smallerDequeued && biggerDequeued)
                {
                    Assert.True(smaller < bigger);
                }
            }
        }
    }
}
