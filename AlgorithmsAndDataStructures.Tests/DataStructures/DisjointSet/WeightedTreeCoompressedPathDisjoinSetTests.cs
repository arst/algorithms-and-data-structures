using AlgorithmsAndDataStructures.DataStructures.DisjointSet;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.DisjointSet
{
    public class WeightedTreeCoompressedPathDisjoinSetTests : DisjoinSetBaseTests
    {
        protected override IDisjointSet GetSut(int size)
        {
            return new WeightedTreeCoompressedPathDisjoinSet(size);
        }
    }
}
