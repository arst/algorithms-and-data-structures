using AlgorithmsAndDataStructures.DataStructures.DisjointSet;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.DisjointSet;

public class WeightedTreeDisjointSetTests : DisjoinSetBaseTests
{
    protected override IDisjointSet GetSut(int size)
    {
        return new WeightedTreeDisjointSet(size);
    }
}