using AlgorithmsAndDataStructures.DataStructures.Stack;
using System;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.Stack
{
    public class LinkedListStackTests
    {
        [Fact]
        public void PopFromEmptyStackThrowsAnException()
        {
            var sut = new LinkedListStack<int>();
            Assert.Throws<ArgumentException>(() => sut.Pop());
        }

        [Fact]
        public void LinkedListStackCorrectlyReportsItsEmptiness()
        {
            var sut = new LinkedListStack<int>();
            Assert.True(sut.IsEmpty);
        }

        [Fact]
        public void LinkedListStackWorksInLifoOrder()
        {
            var sut = new LinkedListStack<int>();
            sut.Push(1);
            sut.Push(2);
            Assert.Equal(2, sut.Pop());
        }

        [Fact]
        public void LinkedListStackIsEnptyWhenAllElementsAreRemoved()
        {
            var sut = new LinkedListStack<int>();
            sut.Push(1);
            sut.Push(2);
            Assert.Equal(2, sut.Pop());
            Assert.Equal(1, sut.Pop());
            Assert.True(sut.IsEmpty);
        }

        [Fact]
        public void LinkedListStackIncreasesCapacityOnDemand()
        {
            var sut = new LinkedListStack<int>();
            sut.Push(1);
            sut.Push(2);
            Assert.Equal(2, sut.Pop());
            Assert.Equal(1, sut.Pop());
            Assert.True(sut.IsEmpty);
        }
    }
}
