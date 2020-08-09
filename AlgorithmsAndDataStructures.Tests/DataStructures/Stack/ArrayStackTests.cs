using System;
using AlgorithmsAndDataStructures.DataStructures.Stack;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.Stack
{
    public class ArrayStackTests
    {
        [Fact]
        public void PopFromEmptyStackThrowsAnException()
        {
            var sut = new ArrayStack<int>();
            Assert.Throws<ArgumentException>(() => sut.Pop());
        }

        [Fact]
        public void ArrayStackCorrectlyReportsItsEmptiness()
        {
            var sut = new ArrayStack<int>();
            Assert.True(sut.IsEmpty);
        }

        [Fact]
        public void ArraStackWorksInLifoOrder()
        {
            var sut = new ArrayStack<int>();
            sut.Push(1);
            sut.Push(2);
            Assert.Equal(2, sut.Pop());
        }

        [Fact]
        public void ArrayStackIsEnptyWhenAllElementsAreRemoved()
        {
            var sut = new ArrayStack<int>();
            sut.Push(1);
            sut.Push(2);
            Assert.Equal(2, sut.Pop());
            Assert.Equal(1, sut.Pop());
            Assert.True(sut.IsEmpty);
        }

        [Fact]
        public void ArrayStackIncreasesCapacityOnDemand()
        {
            var sut = new ArrayStack<int>(1);
            sut.Push(1);
            sut.Push(2);
            Assert.Equal(2, sut.Pop());
            Assert.Equal(1, sut.Pop());
            Assert.True(sut.IsEmpty);
        }
    }
}
