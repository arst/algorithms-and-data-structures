using System.Globalization;
using AlgorithmsAndDataStructures.DataStructures.Cache;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.Cache
{
    public class LruTests
    {
        [Fact]
        public void CanInsertEntry()
        {
            var sut = new Lru(1);
            sut.Add(1, "Test");
        }

        [Fact]
        public void CanGetEntry()
        {
            var sut = new Lru(1);
            sut.Add(1, "Test");

            Assert.Equal("Test", sut.Get(1));
        }

        [Fact]
        public void CanUpdateEntry()
        {
            var sut = new Lru(1);
            sut.Add(1, "Test");
            sut.Add(1, "Test1");

            Assert.Equal("Test1", sut.Get(1));
        }

        [Fact]
        public void LeastRecentlyUsedEntryRemoved()
        {
            var sut = new Lru(1);
            sut.Add(1, "Test");
            sut.Add(2, "Test1");

            Assert.Null(sut.Get(1));
            Assert.Equal("Test1", sut.Get(2));
        }

        [Fact]
        public void Fuzzy()
        {
            const int testCaseSize = 1000;
            var sut = new Lru(testCaseSize);

            for (var i = 0; i < testCaseSize; i++)
            {
                sut.Add(i, i.ToString(CultureInfo.InvariantCulture));
            }

            for (var i = testCaseSize; i < testCaseSize * 2; i++)
            {
                sut.Add(i, i.ToString(CultureInfo.InvariantCulture));
                Assert.Null(sut.Get(i - testCaseSize));
            }
        }
    }
}
