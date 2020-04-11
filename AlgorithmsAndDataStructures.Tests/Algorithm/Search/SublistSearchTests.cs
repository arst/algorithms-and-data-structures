using AlgorithmsAndDataStructures.Algorithms.Search;
using AlgorithmsAndDataStructures.DataStructures.LinkedList;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Search
{
    public class SublistSearchTests
    {
        [Fact]
        public void OneNodeList()
        {
            var sut = new SublistSearch();
            var input = new SinglyLinkedList<int>();
            input.Append(1);
            var pattern = new SinglyLinkedList<int>();
            pattern.Append(1);

            Assert.True(sut.IsSubset(input, pattern));
        }

        [Fact]
        public void PatternLongerThenInput()
        {
            var sut = new SublistSearch();
            var input = new SinglyLinkedList<int>();
            input.Append(1);
            var pattern = new SinglyLinkedList<int>();
            pattern.Append(1);
            pattern.Append(2);

            Assert.False(sut.IsSubset(input, pattern));
        }

        [Fact]
        public void InputLongerThenPattern()
        {
            var sut = new SublistSearch();
            var input = new SinglyLinkedList<int>();
            input.Append(1);
            input.Append(2);
            var pattern = new SinglyLinkedList<int>();
            pattern.Append(1);

            Assert.True(sut.IsSubset(input, pattern));
        }

        [Fact]
        public void MatchAtTheEnd()
        {
            var sut = new SublistSearch();
            var input = new SinglyLinkedList<int>();
            input.Append(1);
            input.Append(2);
            input.Append(1);
            input.Append(2);
            input.Append(3);
            input.Append(4);
            var pattern = new SinglyLinkedList<int>();
            pattern.Append(1);
            pattern.Append(2);
            pattern.Append(3);
            pattern.Append(4);

            Assert.True(sut.IsSubset(input, pattern));
        }

        [Fact]
        public void PartialMatch()
        {
            var sut = new SublistSearch();
            var input = new SinglyLinkedList<int>();
            input.Append(1);
            input.Append(2);
            input.Append(2);
            input.Append(1);
            input.Append(2);
            input.Append(3);
            var pattern = new SinglyLinkedList<int>();
            pattern.Append(1);
            pattern.Append(2);
            pattern.Append(3);
            pattern.Append(4);

            Assert.False(sut.IsSubset(input, pattern));
        }

        [Fact]
        public void MatchInTheMiddle()
        {
            var sut = new SublistSearch();
            var input = new SinglyLinkedList<int>();
            input.Append(1);
            input.Append(2);
            input.Append(1);
            input.Append(2);
            input.Append(3);
            input.Append(4);
            input.Append(1);
            input.Append(2);
            var pattern = new SinglyLinkedList<int>();
            pattern.Append(1);
            pattern.Append(2);
            pattern.Append(3);
            pattern.Append(4);

            Assert.True(sut.IsSubset(input, pattern));
        }
    }
}
