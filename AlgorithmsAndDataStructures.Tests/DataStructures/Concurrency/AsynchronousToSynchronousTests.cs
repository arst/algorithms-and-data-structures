using AlgorithmsAndDataStructures.DataStructures.Concurrency;
using System.Collections.Generic;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.Concurrency
{
    public class AsynchronousToSynchronousTests
    {
        [Fact]
        public void ExecutesSyncronously()
        {
            var sut = new AsynchronousToSynchronous();

            for (var i = 0; i < 10000; i++)
            {
                var queue = new Queue<int>();
                sut.ExecuteSync(queue);
                Assert.Equal(1, queue.Dequeue());
                Assert.Equal(2, queue.Dequeue());
            }
        }
    }
}
