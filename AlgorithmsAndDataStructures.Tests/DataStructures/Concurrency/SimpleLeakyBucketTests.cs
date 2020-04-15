using AlgorithmsAndDataStructures.DataStructures.Concurrency;
using System;
using System.Threading;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.Concurrency
{
    public class SimpleLeakyBucketTests
    {

        [Fact]
        public void CanSendCorrectPacket()
        {
            var sut = new SimpleLeakyBucket(101, 100, 2000);
            var producer = new Thread(Send);
            var result = false;
            producer.Start();
            producer.Join();

            void Send()
            {
                result = sut.TryEnqueue(100);
            }

            Assert.True(result);
        }

        [Fact]
        public void PacketBiggerThenBucketIsDropped()
        {
            var sut = new SimpleLeakyBucket(101, 100, 2000);
            var producer = new Thread(Send);
            var result = true;
            producer.Start();
            producer.Join();


            void Send()
            {
                result = sut.TryEnqueue(102);
            }

            Assert.False(result);
        }

        [Fact]
        public void QueuesPacketsInTheBucket()
        {
            var sut = new SimpleLeakyBucket(200, 100, 20000);
            var producer = new Thread(Send);
            var result1 = false;
            var result2 = false;
            producer.Start();
            producer.Join();


            void Send()
            {
                result1 = sut.TryEnqueue(100);
                result2 = sut.TryEnqueue(100);
            }

            Assert.True(result1);
            Assert.True(result2);
        }

        [Fact]
        public void DropPacketsWhenQueueIsFull()
        {
            var sut = new SimpleLeakyBucket(200, 100, 20000);
            var producer = new Thread(Send);
            var result1 = false;
            var result2 = false;
            var result3 = true;
            producer.Start();
            producer.Join();

            void Send()
            {
                result1 = sut.TryEnqueue(100);
                result2 = sut.TryEnqueue(100);
                result3 = sut.TryEnqueue(100);
            }

            Assert.True(result1);
            Assert.True(result2);
            Assert.False(result3);
        }

        [Fact]
        public void LeaksWithConstantRate()
        {
            var sut = new SimpleLeakyBucket(200, 100, 20000);
            var producer = new Thread(Send);
            var result1 = false;
            var result2 = false;
            var result3 = true;
            var result4 = false;
            producer.Start();
            producer.Join();

            void Send()
            {
                result1 = sut.TryEnqueue(100);
                result2 = sut.TryEnqueue(100);
                result3 = sut.TryEnqueue(100);
                Thread.Sleep(TimeSpan.FromMilliseconds(30000));
                result4 = sut.TryEnqueue(100);
            }

            Assert.True(result1);
            Assert.True(result2);
            Assert.False(result3);
            Assert.True(result4);
        }
    }
}
