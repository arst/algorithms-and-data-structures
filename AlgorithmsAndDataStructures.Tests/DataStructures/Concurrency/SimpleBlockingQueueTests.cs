using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AlgorithmsAndDataStructures.DataStructures.Concurrency;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.Concurrency
{
    public class SimpleBlockingQueueTests
    {
        [Fact]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "HAA0302:Display class allocation to capture closure", Justification = "Code is not a part of the host path. Capture and allocation is ok.")]
        public async Task Baseline()
        {
            var sut = new SimpleBlockingQueue();
            var queue1 = new Queue<int>();
            var queue2 = new Queue<int>();
            const int testSize = 1000000;
#pragma warning disable HAA0302 // Display class allocation to capture closure
            
#pragma warning restore HAA0302 // Display class allocation to capture closure

#pragma warning disable HAA0301 // Closure Allocation Source
            var writerTask = new Task(Write);
            var readerTask1 = new Task(() => Read(1));
            var readerTask2 = new Task(() => Read(2));
#pragma warning restore HAA0301 // Closure Allocation Source
            readerTask1.Start();
            writerTask.Start();
            readerTask2.Start();

            void Write()
            {
                for (var i = 0; i < testSize; i++)
                {
                    using var cancellationTokenSource = new CancellationTokenSource();
                    cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(5));
                    sut.Enqueue(i, TimeSpan.FromSeconds(5), cancellationTokenSource.Token);
                }
            }

            void Read(int queueNumber)
            {
                var currentQueue = queueNumber == 1 ? queue1 : queue2;

                while (queue1.Count + queue2.Count != testSize)
                {
                    using var cancellationTokenSource = new CancellationTokenSource();
                    cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(5));
                    int toEnqueue;

                    try
                    {
                        toEnqueue = sut.Dequeue(TimeSpan.FromSeconds(5), cancellationTokenSource.Token);
                    }
                    catch (OperationCanceledException)
                    {
                        return;
                    }

                    currentQueue.Enqueue(toEnqueue);
                }
            }

#pragma warning disable HAA0101 // Array allocation for params parameter
            await writerTask.ConfigureAwait(false);
            await Task.WhenAll(readerTask1, readerTask2).ConfigureAwait(false);
#pragma warning restore HAA0101 // Array allocation for params parameter

            Assert.True(!queue1.Intersect(queue2).ToList().Any());

            Assert.True(queue1.Distinct().Count() == queue1.Count);

            while (queue1.Count > 0)
            {
                var smallerDequeued = queue1.TryDequeue(out var smaller);
                var biggerDequeued = queue1.TryDequeue(out var bigger);

                if (smallerDequeued && biggerDequeued)
                {
                    Assert.True(smaller < bigger);
                }
                
            }

            Assert.True(queue2.Distinct().Count() == queue2.Count);

            while (queue2.Count > 0)
            {
                var smallerDequeued = queue2.TryDequeue(out var smaller);
                var biggerDequeued = queue2.TryDequeue(out var bigger);

                if (smallerDequeued && biggerDequeued)
                {
                    Assert.True(smaller < bigger);
                }
            }
        }
    }
}
