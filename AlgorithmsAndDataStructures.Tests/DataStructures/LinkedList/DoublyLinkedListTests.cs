using AlgorithmsAndDataStructures.DataStructures.Common;
using AlgorithmsAndDataStructures.DataStructures.LinkedList;
using System.Linq;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.LinkedList
{
    public class DoublyLinkedListTests
    {
        [Fact]
        public void PrependToEmptyDoesntThrowAnError()
        {
            var sut = new DoublyLinkedList<int>();
            sut.Prepend(1);

            Assert.Single(sut.Traverse());
        }

        [Fact]
        public void AppendToEmptyDoesntThrowAnError()
        {
            var sut = new DoublyLinkedList<int>();
            sut.Append(1);

            Assert.Single(sut.Traverse());
        }

        [Fact]
        public void RemoveByPositionFromEmptyListDoesntThrowAnError()
        {
            var sut = new DoublyLinkedList<int>();
            sut.RemoveByPosition(1);
        }

        [Fact]
        public void RemoveByPositionOutsideOfBoundariesDoesntThrowAnError()
        {
            var sut = new DoublyLinkedList<int>(new DoublyNode<int> { Value = 1 });
            sut.RemoveByPosition(1);

            Assert.Single(sut.Traverse());
        }

        [Fact]
        public void RemoveByPositionOutsideOfBoundariesDoesntRemoveNodes()
        {
            var sut = new DoublyLinkedList<int>(new DoublyNode<int> { Value = 1 });
            sut.Append(2);
            sut.Append(3);
            sut.RemoveByPosition(int.MaxValue);

            Assert.Equal(3, sut.Traverse().Count);
        }

        [Fact]
        public void RemoveByMiddlePosition()
        {
            var sut = new DoublyLinkedList<int>(new DoublyNode<int> { Value = 1 });
            sut.Append(2);
            sut.Append(3);
            sut.RemoveByPosition(1);

            Assert.Equal(2, sut.Traverse().Count);
            Assert.Equal(1, sut.Traverse().First());
            Assert.Equal(3, sut.Traverse().Skip(1).First());
        }

        [Fact]
        public void RemoveByStartingPosition()
        {
            var sut = new DoublyLinkedList<int>(new DoublyNode<int> { Value = 1 });
            sut.Append(2);
            sut.Append(3);
            sut.RemoveByPosition(0);

            Assert.Equal(2, sut.Traverse().Count);
            Assert.Equal(2, sut.Traverse().First());
            Assert.Equal(3, sut.Traverse().Skip(1).First());
        }

        [Fact]
        public void RemoveByEndPosition()
        {
            var sut = new DoublyLinkedList<int>(new DoublyNode<int> { Value = 1 });
            sut.Append(2);
            sut.Append(3);
            sut.RemoveByPosition(2);

            Assert.Equal(2, sut.Traverse().Count);
            Assert.Equal(1, sut.Traverse().First());
            Assert.Equal(2, sut.Traverse().Skip(1).First());
        }

        [Fact]
        public void Reverse()
        {
            var sut = new DoublyLinkedList<int>(new DoublyNode<int> { Value = 1 });
            sut.Append(2);
            sut.Append(3);
            var traversed = sut.Traverse();
            sut.Reverse();
            var traverseReverted = sut.Traverse();

            for (int i = 0; i < traversed.Count; i++)
            {
                Assert.Equal(traversed[i], traverseReverted[traverseReverted.Count - i - 1]);
            }
        }
    }
}
