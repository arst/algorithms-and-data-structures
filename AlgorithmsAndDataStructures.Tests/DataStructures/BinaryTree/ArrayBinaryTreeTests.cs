using AlgorithmsAndDataStructures.DataStructures.BinaryTrees;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.BinaryTree;

public class ArrayBinaryTreeTests
{
    [Fact]
    public void ArrayTreeIsExpandedOnDemand()
    {
        var sut = new ArrayBinaryTree<int>(1);
        sut.Root(1);
        sut.SetLeft(1, 2);
        sut.SetRight(1, 3);
        sut.SetLeft(2, 4);
        sut.SetRight(2, 5);

        Assert.Equal(2, sut.GetTree()[2]);
        Assert.Equal(3, sut.GetTree()[3]);
        Assert.Equal(4, sut.GetTree()[4]);
        Assert.Equal(5, sut.GetTree()[5]);
    }
}