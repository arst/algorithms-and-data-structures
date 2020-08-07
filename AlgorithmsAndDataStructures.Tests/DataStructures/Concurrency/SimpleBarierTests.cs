using AlgorithmsAndDataStructures.DataStructures.Concurrency;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.Concurrency
{
    public class SimpleBarierTests
    {
        [Fact]
        public void OneThread()
        {
            var sut = new SimpleBarrier(1);

            var worker = new Thread(DoWork);
            worker.Start();
            worker.Join();

            void DoWork()
            {
                for (var i = 0; i < 1000; i++)
                {
                    sut.Wait();
                }
            }
        }

        [Fact]
        public void TwoThreads()
        {
            var sut = new SimpleBarrier(2);
            var result = new ConcurrentQueue<string>();

            var worker1 = new Thread(DoWork);
            worker1.Start();

            var worker2 = new Thread(DoWork);
            worker2.Start();

            worker1.Join();
            worker2.Join();

            void DoWork()
            {
                for (var i = 0; i < 10; i++)
                {
                    var item = "STAGE:" + i;
                    result.Enqueue(item);
                    sut.Wait();
                }
            }

            while (result.Any())
            {
                result.TryDequeue(out var worker1Item);
                result.TryDequeue(out var worker2Item);

                Assert.Equal(worker1Item, worker2Item);
            }
        }
    }
}
