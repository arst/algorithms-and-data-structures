using AlgorithmsAndDataStructures.DataStructures.Cache;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.Cache
{
    public class LRUTests
    {
        [Fact]
        public void CanInsertEntry()
        {
            var sut = new LRU(1);
            sut.Add(1, "Test");
        }

        [Fact]
        public void CanGetEntry()
        {
            var sut = new LRU(1);
            sut.Add(1, "Test");

            Assert.Equal("Test", sut.Get(1));
        }

        [Fact]
        public void CanUpdateEntry()
        {
            var sut = new LRU(1);
            sut.Add(1, "Test");
            sut.Add(1, "Test1");

            Assert.Equal("Test1", sut.Get(1));
        }

        [Fact]
        public void LeastRecentlyUsedEntryRemoved()
        {
            var sut = new LRU(1);
            sut.Add(1, "Test");
            sut.Add(2, "Test1");

            Assert.Null(sut.Get(1));
            Assert.Equal("Test1", sut.Get(2));
        }

        [Fact]
        public void PropertyBased()
        {
            var testcaseSize = 1000;
            var sut = new LRU(testcaseSize);

            for (int i = 0; i < testcaseSize; i++)
            {
                sut.Add(i, i.ToString());
            }

            for (int i = testcaseSize; i < testcaseSize * 2; i++)
            {
                sut.Add(i, i.ToString());
                Assert.Null(sut.Get(i - testcaseSize));
            }
        }
    }
}
