using AlgorithmsAndDataStructures.DataStructures.SegmentTree;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.SegmentTree
{
    public class SumSegmentTreeTests
    {
        [Fact]
        public void CanConstructSegmentTreeFromArray()
        {
            var sut = new SumSegmentTree(new int[] { 1,3,5,7,9,11 });
        }
    }
}
