using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Misc.BanzhafMeasure
{
    public class BanzhafMeasurementTests
    {
        [Fact]
        public void SimpleMeasure()
        {
            var sut = new Algorithms.Misc.CloutMeasurement.BanzhafMeasurement();
            var votingPower = sut.Measure(
                "A",
                new[] { "B", "C", "D" },
                6,
                new System.Collections.Generic.Dictionary<string, int>
                {
                    { "A", 4 },
                    { "B", 2 },
                    { "C", 1 },
                    { "D", 3 }
                },
                1000);

            // This is probalistic algorithm that uses Monte Carlo simulation so it's kinda hard to predict the actual result.
            // In this particular case we have expected value of 0.625 since there are 8 possible coalitions without A with 5 of them become critical with addition of A.
            // Therefore Banzhaf measure for A is 5/8.
            Assert.True(votingPower > 0.5);
        }
    }
}
