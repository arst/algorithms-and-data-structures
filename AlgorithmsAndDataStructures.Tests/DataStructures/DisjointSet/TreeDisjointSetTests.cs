using AlgorithmsAndDataStructures.DataStructures.DisjointSet;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.DisjointSet;

public class TreeDisjointSetTests : DisjoinSetBaseTests
{
    protected override IDisjointSet GetSut(int size)
    {
        return new TreeDisjointSet(size);
    }
}