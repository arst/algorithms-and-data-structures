using AlgorithmsAndDataStructures.DataStructures.HashTable;
using System;
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
            var sut = new SeparateChainingHashTable<string, int>();
            sut.Add("One", 1);
            sut.Delete("One");
            Assert.Throws<ArgumentException>(() => sut.Get("One"));
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
        public void SeparateChainingMaintaincHashTable()
        {
            var sut = new SeparateChainingHashTable<string, int>(100000);

            for (int i = 0; i < 100000; i++)
            {
                sut.Add(i.ToString(), i);
            }
            for (int i = 0; i < 100000; i++)
            {
                Assert.Equal(i, sut.Get(i.ToString()));
            }
            for (int i = 0; i < 100000; i++)
            {
                sut.Add(i.ToString(), i * 2);
            }
            for (int i = 0; i < 100000; i++)
            {
                Assert.Equal(i * 2, sut.Get(i.ToString()));
            }
            for (int i = 0; i < 100000; i++)
            {
                sut.Delete(i.ToString());
            }
            for (int i = 0; i < 100000; i++)
            {
                Assert.False(sut.Find(i.ToString()));
            }
        }
    }
}
