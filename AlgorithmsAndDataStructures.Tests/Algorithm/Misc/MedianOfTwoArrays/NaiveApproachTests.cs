using AlgorithmsAndDataStructures.Algorithms.Misc.MedianOfTwoArrays;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Misc.MedianOfTwoArrays
{
    public class NaiveApproachTests : MedianOfTwoArraysTests
    {
        protected override IMediaOfTwoArraysAlgorithm GetSut()
        {
            return new NaiveApproach();
        }
    }
}
