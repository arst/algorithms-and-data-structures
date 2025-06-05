using AlgorithmsAndDataStructures.Algorithms.Misc.MedianOfTwoArrays;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Misc.MedianOfTwoArrays;

public class BinarySearchApproachTests : MedianOfTwoArraysTests
{
    protected override IMediaOfTwoArraysAlgorithm GetSut()
    {
        return new BinarySearchApproach();
    }
}