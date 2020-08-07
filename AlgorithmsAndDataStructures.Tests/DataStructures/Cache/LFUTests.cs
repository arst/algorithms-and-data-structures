using AlgorithmsAndDataStructures.DataStructures.Cache;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.Cache
{
    public class LFUTests
    {
        [Fact]
        public void CanInsertEntry()
        {
            var sut = new LFU(1);
            sut.Add(1, "Test");
        }

        [Fact]
        public void CanGetEntry()
        {
            var sut = new LFU(1);
            sut.Add(1, "Test");

            Assert.Equal("Test", sut.Get(1));
        }

        [Fact]
        public void CanUpdateEntry()
        {
            var sut = new LFU(1);
            sut.Add(1, "Test");
            sut.Add(1, "Test1");

            Assert.Equal("Test1", sut.Get(1));
        }

        [Fact]
        public void LeastFrequentlyUsedEntryRemoved()
        {
            var sut = new LRU(2);
            sut.Add(1, "Test");
            sut.Add(2, "Test1");
            sut.Get(2);
            sut.Add(3, "Test2");

            Assert.Null(sut.Get(1));
            Assert.Equal("Test1", sut.Get(2));
            Assert.Equal("Test2", sut.Get(3));
        }

        [Fact]
        public void PropertyBased()
        {
            var testcaseSize = 10;
            var sut = new LFU(testcaseSize);

            for (var i = 0; i < testcaseSize - 1; i++)
            {
                sut.Add(i, i.ToString());
            }

            sut.Add(testcaseSize, testcaseSize.ToString());

            for (var i = testcaseSize + 1; i < testcaseSize * 2; i++)
            {
                for (var j = 0; j < testcaseSize; j++)
                {
                    sut.Get(j);
                }

                sut.Add(i, i.ToString());

                Assert.Null(sut.Get(i - testcaseSize - 1));
            }
        }
    }
}
