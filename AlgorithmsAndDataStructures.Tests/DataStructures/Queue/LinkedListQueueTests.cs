using AlgorithmsAndDataStructures.DataStructures.Queue;
using System;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.Queue
{
    public class LinkedListQueueTests
    {
        [Fact]
        public void PopFromEmptyQueueThrowsAnException()
        {
            var sut = new LinkedListQueue<int>();
            Assert.Throws<ArgumentException>(() => sut.Dequeue());
        }

        [Fact]
        public void QueueStackCorrectlyReportsItsEmptiness()
        {
            var sut = new LinkedListQueue<int>();
            Assert.True(sut.IsEmpty);
        }

        [Fact]
        public void QueueStackWorksInFifoOrder()
        {
            var sut = new LinkedListQueue<int>();
            for (int i = 0; i < 100; i++)
            {
                sut.Enqueue(i);
            }
            for (int i = 0; i < 100; i++)
            {
                Assert.Equal(i, sut.Dequeue());
            }
        }

        [Fact]
        public void QueueIsEnptyWhenAllElementsAreRemoved()
        {
            var sut = new LinkedListQueue<int>();
            sut.Enqueue(1);
            sut.Enqueue(2);
            Assert.Equal(1, sut.Dequeue());
            Assert.Equal(2, sut.Dequeue());
            Assert.True(sut.IsEmpty);
        }

        [Fact]
        public void CircularQueueRemovesOldElementsToEnqueueNewOnes1()
        {
            var sut = new LinkedListQueue<int>();
            sut.Enqueue(1);
            sut.Enqueue(2);
            Assert.Equal(1, sut.Dequeue());
            Assert.Equal(2, sut.Dequeue());
            sut.Enqueue(4);
            Assert.Equal(4, sut.Dequeue());
            Assert.True(sut.IsEmpty);
        }

        [Fact]
        public void QueueWorksInFifoOrderWhenIntermittentEnqueuesAccure()
        {
            var sut = new LinkedListQueue<int>();
            sut.Enqueue(1);
            sut.Enqueue(2);
            sut.Enqueue(3);
            Assert.Equal(1, sut.Dequeue());
            sut.Enqueue(4);
            sut.Enqueue(5);
            Assert.Equal(2, sut.Dequeue());
            Assert.Equal(3, sut.Dequeue());
            Assert.Equal(4, sut.Dequeue());
            Assert.Equal(5, sut.Dequeue());
        }
    }
}
