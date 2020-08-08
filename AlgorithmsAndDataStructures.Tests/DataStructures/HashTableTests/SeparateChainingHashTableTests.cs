using AlgorithmsAndDataStructures.DataStructures.HashTable;
using System;
using System.Globalization;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.DataStructures.HashTableTests
{
    public class SeparateChainingHashTableTests
    {
        [Fact]
        public void CanAddEntryToHashTable()
        {
            var sut = new SeparateChainingHashTable<string, int>();
            sut.Add("One", 1);
        }

        [Fact]
        public void CanDeleteEntryFromHashTable()
        {
#pragma warning disable HAA0302 // Display class allocation to capture closure
            var sut = new SeparateChainingHashTable<string, int>();
#pragma warning restore HAA0302 // Display class allocation to capture closure
            sut.Add("One", 1);
            sut.Delete("One");
#pragma warning disable HAA0301 // Closure Allocation Source
            _ = Assert.Throws<ArgumentException>(() => sut.Get("One"));
#pragma warning restore HAA0301 // Closure Allocation Source
        }

        [Fact]
        public void CanDeleteNonExistingEntryFromHashTable()
        {
            var sut = new SeparateChainingHashTable<string, int>();
            sut.Add("One", 1);
            sut.Delete("Two");
        }

        [Fact]
        public void CanFindEntryInHashTable()
        {
            var sut = new SeparateChainingHashTable<string, int>();
            sut.Add("One", 1);
            Assert.True(sut.Find("One"));
        }

        [Fact]
        public void FindForNonExistingEntryReturnFalse()
        {
            var sut = new SeparateChainingHashTable<string, int>();
            sut.Add("One", 1);
            Assert.False(sut.Find("Two"));
        }

        [Fact]
        public void CanGetEntryFromHashTable()
        {
            var sut = new SeparateChainingHashTable<string, int>();
            sut.Add("One", 1);
            Assert.True(sut.Find("One"));
        }

        [Fact]
        public void CanUpdateHashEntryValue()
        {
            var sut = new SeparateChainingHashTable<string, int>(2);
            sut.Add("One", 1);
            sut.Add("Two", 2);
            sut.Add("Two", 3);
            Assert.Equal(3, sut.Get("Two"));
        }

        // TODO: Convert to property based testing.
        [Fact]
        public void SeparateChainingMaintenanceHashTable()
        {
            var sut = new SeparateChainingHashTable<string, int>(100000);

            for (var i = 0; i < 100000; i++)
            {
                sut.Add(i.ToString(CultureInfo.InvariantCulture), i);
            }
            for (var i = 0; i < 100000; i++)
            {
                Assert.Equal(i, sut.Get(i.ToString(CultureInfo.InvariantCulture)));
            }
            for (var i = 0; i < 100000; i++)
            {
                sut.Add(i.ToString(CultureInfo.InvariantCulture), i * 2);
            }
            for (var i = 0; i < 100000; i++)
            {
                Assert.Equal(i * 2, sut.Get(i.ToString(CultureInfo.InvariantCulture)));
            }
            for (var i = 0; i < 100000; i++)
            {
                sut.Delete(i.ToString(CultureInfo.InvariantCulture));
            }
            for (var i = 0; i < 100000; i++)
            {
                Assert.False(sut.Find(i.ToString(CultureInfo.InvariantCulture)));
            }
        }
    }
}
