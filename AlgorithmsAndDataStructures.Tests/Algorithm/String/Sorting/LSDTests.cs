using AlgorithmsAndDataStructures.Algorithms.String.Sorting;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.String.Sorting
{
    public class LSDTests
    {
        [Fact]
        public void Baseline()
        {
            var sut = new Lsd();

            var input = new[]
                {
                    "4PGC938",
                    "2IYE230",
                    "3CIO720",
                    "1ICK750",
                    "1OHV845",
                    "4JZY524",
                    "1ICK750",
                    "3CIO720",
                    "1OHV845",
                    "1OHV845",
                    "2RLA629",
                    "2RLA629",
                    "3ATW723"
                };

            Assert.Collection(sut.Sort(input, 6),
                arg => Assert.Equal("1ICK750", arg),
                arg => Assert.Equal("1ICK750", arg),
                arg => Assert.Equal("1OHV845", arg),
                arg => Assert.Equal("1OHV845", arg),
                arg => Assert.Equal("1OHV845", arg),
                arg => Assert.Equal("2IYE230", arg),
                arg => Assert.Equal("2RLA629", arg),
                arg => Assert.Equal("2RLA629", arg),
                arg => Assert.Equal("3ATW723", arg),
                arg => Assert.Equal("3CIO720", arg),
                arg => Assert.Equal("3CIO720", arg),
                arg => Assert.Equal("4JZY524", arg),
                arg => Assert.Equal("4PGC938", arg));
        }
    }
}
