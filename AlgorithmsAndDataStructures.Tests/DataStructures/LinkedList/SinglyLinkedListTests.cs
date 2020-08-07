using AlgorithmsAndDataStructures.DataStructures.Common;
using AlgorithmsAndDataStructures.DataStructures.LinkedList;
using System.Linq;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.LinkedList
{
    public class SinglyLinkedListTests
    {
        [Fact]
        public void TraversalForEmptyListReturnsEmptyList()
        {
            var sut = new SinglyLinkedList<int>();
            Assert.Empty(sut.Traverse());
        }

        [Fact]
        public void TraversalForSimpleLinkedListWithHeadOnlyReturnsListWithOneElement()
        {
            var sut = new SinglyLinkedList<int>(new Node<int> { Value = 1 });
            Assert.Single(sut.Traverse());
            Assert.Equal(1, sut.Traverse().First());
        }

        [Fact]
        public void TraversalForSimpleLinkedListWithHeadAndTailReturnsListWithTwoElements()
        {
            var sut = new SinglyLinkedList<int>(new Node<int> { Value = 1 });
            sut.Append(2);
            Assert.Equal(2, sut.Traverse().Count);
            Assert.Equal(1, sut.Traverse().First());
            Assert.Equal(2, sut.Traverse().Skip(1).First());
        }

        [Fact]
        public void RemoveFromEmptySimpleLinkedListEmptyDoesntThrowAnException()
        {
            var sut = new SinglyLinkedList<int>();
            sut.RemoveByValue(1);
        }

        [Fact]
        public void RemoveFromSimpleLinkedListEmptyDoesntThrowAnExceptionWhenValueNotFound()
        {
            var sut = new SinglyLinkedList<int>(new Node<int> { Value = 1 });
            sut.Append(2);
            sut.Append(3);
            sut.RemoveByValue(4);
        }

        [Fact]
        public void RemoveHeadMakesSimpleLinkedListEmpty()
        {
            var sut = new SinglyLinkedList<int>(new Node<int> { Value = 1 });
            sut.RemoveByValue(1);
            Assert.Empty(sut.Traverse());
        }

        [Fact]
        public void RemoveNodeFromTheMiddleOfSimpleLinkedList()
        {
            var sut = new SinglyLinkedList<int>(new Node<int> { Value = 1 });
            sut.Append(2);
            sut.Append(3);
            sut.RemoveByValue(2);

            Assert.Equal(2, sut.Traverse().Count);
            Assert.Equal(1, sut.Traverse().First());
            Assert.Equal(3, sut.Traverse().Skip(1).First());
        }

        [Fact]
        public void RemoveNodeFromTheTailSimpleLinkedList()
        {
            var sut = new SinglyLinkedList<int>(new Node<int> { Value = 1 });
            sut.Append(2);
            sut.Append(3);
            sut.RemoveByValue(3);

            Assert.Equal(2, sut.Traverse().Count);
            Assert.Equal(1, sut.Traverse().First());
            Assert.Equal(2, sut.Traverse().Skip(1).First());
        }

        [Fact]
        public void RemoveNodeFromTheHeadSimpleLinkedList()
        {
            var sut = new SinglyLinkedList<int>(new Node<int> { Value = 1 });
            sut.Append(2);
            sut.Append(3);
            sut.RemoveByValue(1);

            Assert.Equal(2, sut.Traverse().Count);
            Assert.Equal(2, sut.Traverse().First());
            Assert.Equal(3, sut.Traverse().Skip(1).First());
        }

        [Fact]
        public void TailIsPreservedAfterRemovalFromSimpleLinkedList()
        {
            var sut = new SinglyLinkedList<int>(new Node<int> { Value = 1 });
            sut.Append(2);
            sut.Append(3);
            sut.RemoveByValue(3);
            sut.Append(4);

            Assert.Equal(3, sut.Traverse().Count);
            Assert.Equal(1, sut.Traverse().First());
            Assert.Equal(2, sut.Traverse().Skip(1).First());
            Assert.Equal(4, sut.Traverse().Skip(2).First());
        }

        [Fact]
        public void PrependForEmptyListCreatesHeadOfSimpleLinkedList()
        {
            var sut = new SinglyLinkedList<int>();
            sut.Prepend(3);

            Assert.Single(sut.Traverse());
            Assert.Equal(3, sut.Traverse().First());
        }

        [Fact]
        public void PrependChangesHeadOfSimpleLinkedList()
        {
            var sut = new SinglyLinkedList<int>(new Node<int> { Value = 1 });
            sut.Append(2);
            sut.Prepend(3);

            Assert.Equal(3, sut.Traverse().Count);
            Assert.Equal(3, sut.Traverse().First());
            Assert.Equal(1, sut.Traverse().Skip(1).First());
            Assert.Equal(2, sut.Traverse().Skip(2).First());
        }

        [Fact]
        public void PrependCreatesReverseSimpleLinkedList()
        {
            var sut = new SinglyLinkedList<int>();

            for (var i = 5; i > -1; i--)
            {
                sut.Prepend(i);
            }

            var traversedSut = sut.Traverse();

            Assert.Equal(6, traversedSut.Count);
            
            for (var i = 0; i < traversedSut.Count; i++)
            {
                Assert.Equal(i, traversedSut[i]);
            }
        }

        [Fact]
        public void RemoveByPositionFromEmptyListSimpleLinkedListDoesntThrowAnError()
        {
            var sut = new SinglyLinkedList<int>();
            sut.RemoveByPosition(1);            
        }

        [Fact]
        public void RemoveByPositionOutsideBoundariesOfSimpleLinkedListDoesntThrowAnError()
        {
            var sut = new SinglyLinkedList<int>(new Node<int> { Value = 1 });
            sut.RemoveByPosition(1);

            Assert.Single(sut.Traverse());
        }

        [Fact]
        public void RemoveByPositionOutsideBoundariesOfSimpleLinkedListDoesntRemoveNodes()
        {
            var sut = new SinglyLinkedList<int>(new Node<int> { Value = 1 });
            sut.Append(2);
            sut.Append(3);
            sut.RemoveByPosition(int.MaxValue);

            Assert.Equal(3, sut.Traverse().Count);
        }

        [Fact]
        public void RemoveByMiddlePositionInSimpleLinkedList()
        {
            var sut = new SinglyLinkedList<int>(new Node<int> { Value = 1 });
            sut.Append(2);
            sut.Append(3);
            sut.RemoveByPosition(1);

            Assert.Equal(2, sut.Traverse().Count);
            Assert.Equal(1, sut.Traverse().First());
            Assert.Equal(3, sut.Traverse().Skip(1).First());
        }

        [Fact]
        public void RemoveByStartingPositionInSimpleLinkedList()
        {
            var sut = new SinglyLinkedList<int>(new Node<int> { Value = 1 });
            sut.Append(2);
            sut.Append(3);
            sut.RemoveByPosition(0);

            Assert.Equal(2, sut.Traverse().Count);
            Assert.Equal(2, sut.Traverse().First());
            Assert.Equal(3, sut.Traverse().Skip(1).First());
        }

        [Fact]
        public void RemoveByEndPositionInSimpleLinkedList()
        {
            var sut = new SinglyLinkedList<int>(new Node<int> { Value = 1 });
            sut.Append(2);
            sut.Append(3);
            sut.RemoveByPosition(2);

            Assert.Equal(2, sut.Traverse().Count);
            Assert.Equal(1, sut.Traverse().First());
            Assert.Equal(2, sut.Traverse().Skip(1).First());
        }

        [Fact]
        public void TraverseRecursiveMatchesItterativeRaverse()
        {
            var sut = new SinglyLinkedList<int>(new Node<int> { Value = 1 });
            sut.Append(2);
            sut.Append(3);

            var traversedSut = sut.Traverse();
            var recursivelyTraversedSut = sut.TraverseRecursive();

            for (var i = 0; i < traversedSut.Count; i++)
            {
                Assert.Equal(traversedSut[i], recursivelyTraversedSut[i]);
            }
        }

        [Fact]
        public void TraverseRecursiveForEmptyListReturnsEmptyList()
        {
            var sut = new SinglyLinkedList<int>(null);

            Assert.Empty(sut.TraverseRecursive());
        }

        [Fact]
        public void ReverseItterative()
        {
            var sut = new SinglyLinkedList<int>(new Node<int> { Value = 1 });
            sut.Append(2);
            sut.Append(3);
            var traversed = sut.Traverse();
            sut.ReverseIterative();
            var traverseReverted = sut.Traverse();

            for (var i = 0; i < traversed.Count; i++)
            {
                Assert.Equal(traversed[i], traverseReverted[traverseReverted.Count - i - 1]);
            }
        }

        [Fact]
        public void ReverseRecursive()
        {
            var sut = new SinglyLinkedList<int>(new Node<int> { Value = 1 });
            sut.Append(2);
            sut.Append(3);
            var traversed = sut.Traverse();
            sut.ReverseRecursive();
            var traverseReverted = sut.Traverse();

            for (var i = 0; i < traversed.Count; i++)
            {
                Assert.Equal(traversed[i], traverseReverted[traverseReverted.Count - i - 1]);
            }
        }
    }
}
