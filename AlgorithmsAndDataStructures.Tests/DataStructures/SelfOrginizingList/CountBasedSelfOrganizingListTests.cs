using AlgorithmsAndDataStructures.DataStructures.SelfOrganizingList;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.SelfOrginizingListTests
{
    public class CountBasedSelfOrganizingListTests
    {
        [Fact]
        public void RecentAccessedNodeIsMovedToHead()
        {
            var sut = new CountBasedSelfOrganizingList<int>();

            for (var i = 0; i < 10; i++)
            {
                sut.Add(i);
            }

            sut.Get(9);

            Assert.Equal(9, sut.Head.Value);
        }

        [Fact]
        public void LastAccessNodesAreOnTheTop()
        {
            var sut = new CountBasedSelfOrganizingList<int>();

            for (var i = 0; i < 10; i++)
            {
                sut.Add(i);
            }

            for (var i = 0; i < 10; i++)
            {
                sut.Get(i);
            }

            var current = sut.Head;

            for (var i = 9; i > -1; i--)
            {
                Assert.Equal(i, current.Value);
                current = current.Next;
            }
        }

        [Fact]
        public void TopAccessedNodeIsAtTheHead()
        {
            var sut = new CountBasedSelfOrganizingList<int>();

            for (var i = 0; i < 10; i++)
            {
                sut.Add(i);
            }

            sut.Get(9);
            sut.Get(8);
            sut.Get(8);
            sut.Get(8);
            sut.Get(9);

            Assert.Equal(8, sut.Head.Value);
        }
    }
}
