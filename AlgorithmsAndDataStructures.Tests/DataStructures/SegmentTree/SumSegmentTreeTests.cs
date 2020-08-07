using AlgorithmsAndDataStructures.DataStructures.SegmentTree;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.SegmentTree
{
    public class SumSegmentTreeTests
    {
        [Fact]
        public void CanConstructSegmentTreeFromArray()
        {
            var sut = new SumSegmentTree(new[] { 1, 3, 5, 7, 9, 11 });
        }

        [Fact]
        public void CanGetSum() 
        {
            var sut = new SumSegmentTree(new[] { 1, 3, 5, 7, 9, 11 });

            Assert.Equal(15, sut.GetSegmentValue(1,3));
        }

        [Fact]
        public void CanUpdateValue()
        {
            var sut = new SumSegmentTree(new[] { 1, 3, 5, 7, 9, 11 });

            Assert.Equal(15, sut.GetSegmentValue(1, 3));

            sut.Update(2, 10);

            Assert.Equal(20, sut.GetSegmentValue(1, 3));
        }
    }
}
