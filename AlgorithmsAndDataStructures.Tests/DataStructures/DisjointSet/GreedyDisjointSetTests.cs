using AlgorithmsAndDataStructures.DataStructures.DisjointSet;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.DisjointSet;

public class GreedyDisjointSetTests : DisjoinSetBaseTests
{
    protected override IDisjointSet GetSut(int size)
    {
        return new GreedyDisjointSet(size);
    }
}