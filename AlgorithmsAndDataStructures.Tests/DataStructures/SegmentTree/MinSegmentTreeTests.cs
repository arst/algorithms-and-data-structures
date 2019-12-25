using AlgorithmsAndDataStructures.DataStructures.SegmentTree;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.SegmentTree
{
    public class MinSegmentTreeTests
    {
        [Fact]
        public void GetMin()
        {
            var sut = new MinSegmentTree(new int[] { 1, 3, 5, 7, 9, 11 });

            Assert.Equal(3, sut.GetSegmentValue(1, 3));
        }

        [Fact]
        public void CanUpdateValue()
        {
            var sut = new MinSegmentTree(new int[] { 1, 3, 5, 7, 9, 11 });

            Assert.Equal(3, sut.GetSegmentValue(1, 3));

            sut.Update(1, 8);

            Assert.Equal(5, sut.GetSegmentValue(1, 3));
        }
    }
}
