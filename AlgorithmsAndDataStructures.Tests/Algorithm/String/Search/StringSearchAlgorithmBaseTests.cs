using AlgorithmsAndDataStructures.Algorithms.String.Search;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.String.Search
{
    public abstract class StringSearchAlgorithmBaseTests
    {
        [Fact]
        public void EmptyStringIsNotMatchedWithAnyPattern()
        {
            var sut = GetSystemUnderTest();

            Assert.Equal(-1, sut.Search(string.Empty, " "));
        }

        [Fact]
        public void OneCharacterPatternIsMatched()
        {
            var sut = GetSystemUnderTest();

            Assert.Equal(0, sut.Search("a", "a"));
        }

        [Fact]
        public void StartSubstringIsMatched()
        {
            var sut = GetSystemUnderTest();

            Assert.Equal(0, sut.Search("start", "sta"));
        }

        [Fact]
        public void MiddleSubstringIsMatched()
        {
            var sut = GetSystemUnderTest();

            Assert.Equal(1, sut.Search("start", "tar"));
        }

        [Fact]
        public void EndSubstringIsMatched()
        {
            var sut = GetSystemUnderTest();

            Assert.Equal(2, sut.Search("start", "art"));
        }

        [Fact]
        public void PatternLongerThenStringIsNotMatched()
        {
            var sut = GetSystemUnderTest();

            Assert.Equal(-1, sut.Search("start", "starta"));
        }

        [Fact]
        public void ForRepeatedPatternFirstOccurenceIsMatched()
        {
            var sut = GetSystemUnderTest();

            Assert.Equal(2, sut.Search("startartart", "art"));
        }

        protected abstract IStringPatternSearchAlgorithm GetSystemUnderTest();
    }
}
