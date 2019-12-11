using AlgorithmsAndDataStructures.DataStructures.UnrolledLinkedList;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.UnrolledLinkedList
{
    public class UnrolledLinkedListTests
    {
        [Fact]
        public void UnrolledLinkedListUnrollsIntoArray()
        {
            var sut = new UnrolledLinkedList<int>();

            for (int i = 0; i < 10000; i++)
            {
                sut.Add(i);
            }

            var unrolled = sut.Unroll();

            for (int i = 0; i < 10000; i++)
            {
                Assert.Equal(i, unrolled[i]);
            }
        }

        [Fact]
        public void CanFindElements()
        {
            var sut = new UnrolledLinkedList<int>();

            for (int i = 0; i < 6; i++)
            {
                sut.Add(i);
            }

            var node = sut.Find(5);

            Assert.Equal(1, node.CurrentIndex);
            Assert.Equal(5, node.Values[0]);
        }
    }
}
