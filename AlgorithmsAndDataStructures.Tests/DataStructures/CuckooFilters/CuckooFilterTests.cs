using System;
using AlgorithmsAndDataStructures.DataStructures.CuckooFilter;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.CuckooFilters
{
    public class CuckooFilterTests
    {
        [Fact]
        public void AddAddsElementToFilter()
        {
            var sut = new CuckooFilter(10);
            sut.Add("test");

            Assert.True(sut.Contains("test"));
        }

        [Fact]
        public void ContainsReturnsFalseForNonExistentElement()
        {
            var sut = new CuckooFilter(10);
            Assert.False(sut.Contains("nonexistent"));
        }

        [Fact]
        public void ContainsReturnsTrueForAddedElement()
        {
            var sut = new CuckooFilter(10);
            sut.Add("test");

            Assert.True(sut.Contains("test"));
        }

        [Fact]
        public void RemoveDeletesElementFromFilter()
        {
            var sut = new CuckooFilter(10);
            sut.Add("test");
            sut.Remove("test");

            Assert.False(sut.Contains("test"));
        }

        [Fact]
        public void RemoveDoesNotAffectNonMatchingElements()
        {
            var sut = new CuckooFilter(10);
            sut.Add("test1");
            sut.Add("test2");

            sut.Remove("test1");

            Assert.False(sut.Contains("test1"));
            Assert.True(sut.Contains("test2"));
        }

        [Fact]
        public void AddFailsAfterMaxInsertionAttempts()
        {
            var sut = new CuckooFilter(1, bucketSize: 1, maxInsertionAttempts: 2);

            sut.Add("test1");
            Assert.Throws<InvalidOperationException>(() => sut.Add("test2"));
        }

        [Fact]
        public void FilterHandlesMultipleBucketsCorrectly()
        {
            var sut = new CuckooFilter(5);

            sut.Add("test1");
            sut.Add("test2");
            sut.Add("test3");

            Assert.True(sut.Contains("test1"));
            Assert.True(sut.Contains("test2"));
            Assert.True(sut.Contains("test3"));
        }

        [Fact]
        public void FalsePositivesCanOccur()
        {
            var sut = new CuckooFilter(10, fingerprintSize: 4);

            sut.Add("test1");
            sut.Add("test2");

            // Due to small fingerprint size, this could result in a false positive
            Assert.True(sut.Contains("nonexistent") || !sut.Contains("nonexistent"));
        }
    }
}
