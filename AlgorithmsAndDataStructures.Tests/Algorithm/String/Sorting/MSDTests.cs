using AlgorithmsAndDataStructures.Algorithms.String.Sorting;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.String.Sorting
{
    public class MSDTests
    {
        [Fact]
        public void BaselineSameLength()
        {
            var sut = new MSD();

            var input = new string[]
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

            Assert.Collection(sut.Sort(input),
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

        [Fact]
        public void BaselineDifferentLength()
        {
            var sut = new MSD();

            var input = new string[]
                {
                    "she",
                    "sells",
                    "seashells",
                    "by",
                    "the",
                    "sea",
                    "shore",
                    "the",
                    "shells",
                    "she",
                    "sells",
                    "are",
                    "surely",
                    "seashells"
                };

            Assert.Collection(sut.Sort(input),
                arg => Assert.Equal("are", arg),
                arg => Assert.Equal("by", arg),
                arg => Assert.Equal("sea", arg),
                arg => Assert.Equal("seashells", arg),
                arg => Assert.Equal("seashells", arg),
                arg => Assert.Equal("sells", arg),
                arg => Assert.Equal("sells", arg),
                arg => Assert.Equal("she", arg),
                arg => Assert.Equal("she", arg),
                arg => Assert.Equal("shells", arg),
                arg => Assert.Equal("shore", arg),
                arg => Assert.Equal("surely", arg),
                arg => Assert.Equal("the", arg),
                arg => Assert.Equal("the", arg));
        }
    }
}
