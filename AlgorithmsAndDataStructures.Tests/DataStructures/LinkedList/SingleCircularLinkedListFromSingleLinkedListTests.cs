using AlgorithmsAndDataStructures.DataStructures.Common;
using AlgorithmsAndDataStructures.DataStructures.LinkedList;
using System.Linq;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.LinkedList
{
    public class SingleCircularLinkedListFromSingleLinkedListTests
    {
        [Fact]
        public void OneNodeListHasTheSameRearAndFront()
        {
            var sut = SinglyCircularLinkedList<int>.FromSingleLinkedList(new SinglyLinkedList<int>());

            sut.Enqueue(1);

            Assert.Same(sut.GetFront(), sut.GetRear());
        }

        [Fact]
        public void EmptyListHasNoRearAndFront()
        {
            var sut = SinglyCircularLinkedList<int>.FromSingleLinkedList(new SinglyLinkedList<int>());

            Assert.Null(sut.GetFront());
            Assert.Null(sut.GetRear());
        }

        [Fact]
        public void DequeFromEmptyListDoesntThrowAnError()
        {
            var sut = SinglyCircularLinkedList<int>.FromSingleLinkedList(new SinglyLinkedList<int>());

            Assert.Null(sut.Dequeue());
        }

        [Fact]
        public void Dequeue()
        {
            var node = new Node<int>()
            {
                Value = 1,
                Next = new Node<int>()
                {
                    Value = 2,
                    Next = new Node<int>()
                    {
                        Value = 3,
                        Next = null
                    }
                }
            };

            var sut = SinglyCircularLinkedList<int>.FromSingleLinkedList(new SinglyLinkedList<int>(node));

            Assert.Equal(1, sut.Dequeue().Value);
        }

        [Fact]
        public void Traverse()
        {
            var node = new Node<int>()
            {
                Value = 1,
                Next = new Node<int>()
                {
                    Value = 2,
                    Next = new Node<int>()
                    {
                        Value = 3,
                        Next = null
                    }
                }
            };
            var sut = SinglyCircularLinkedList<int>.FromSingleLinkedList(new SinglyLinkedList<int>(node));
           
            Assert.Equal(3, sut.Traverse().Count);
            Assert.Equal(1, sut.Traverse().First());
            Assert.Equal(2, sut.Traverse().Skip(1).First());
            Assert.Equal(3, sut.Traverse().Skip(2).First());
        }

        [Fact]
        public void DequeueEmptiesSingleNodeList()
        {
            var sut = SinglyCircularLinkedList<int>.FromSingleLinkedList(new SinglyLinkedList<int>(new Node<int>() { Value = 1 }));
            sut.Dequeue();

            Assert.Empty(sut.Traverse());
        }

        [Fact]
        public void DequeueEmptiesList()
        {
            var node = new Node<int>()
            {
                Value = 1,
                Next = new Node<int>()
                {
                    Value = 2,
                    Next = new Node<int>()
                    {
                        Value = 3,
                        Next = null
                    }
                }
            };
            var sut = SinglyCircularLinkedList<int>.FromSingleLinkedList(new SinglyLinkedList<int>(node));
            sut.Dequeue();
            sut.Dequeue();
            sut.Dequeue();

            Assert.Empty(sut.Traverse());
        }

        [Fact]
        public void DequeueReturnsElementsInOrderReversedToEnqueue()
        {
            var node = new Node<int>()
            {
                Value = 1,
                Next = new Node<int>()
                {
                    Value = 2,
                    Next = new Node<int>()
                    {
                        Value = 3,
                        Next = null
                    }
                }
            };
            var sut = SinglyCircularLinkedList<int>.FromSingleLinkedList(new SinglyLinkedList<int>(node));
            var first = sut.Dequeue();
            var second = sut.Dequeue();
            var third = sut.Dequeue();

            Assert.Empty(sut.Traverse());
            Assert.Equal(1, first.Value);
            Assert.Equal(2, second.Value);
            Assert.Equal(3, third.Value);
        }
    }
}
