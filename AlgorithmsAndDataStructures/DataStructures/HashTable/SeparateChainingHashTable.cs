using System;
using System.Linq;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.DataStructures.HashTable
{
    public class SeparateChainingHashTable<TKey, TValue>
    {
        private readonly LinkedList<HashEntry<TKey, TValue>>[] hashTable;

        public SeparateChainingHashTable(int hashTableSize = 8)
        {
            hashTable = new LinkedList<HashEntry<TKey, TValue>>[hashTableSize];
        }

        public void Add(TKey key, TValue value)
        {
            var hash = Math.Abs(key.GetHashCode() % hashTable.Length);

            hashTable[hash] ??= new LinkedList<HashEntry<TKey, TValue>>();

            var entry = hashTable[hash]?.FirstOrDefault(arg => arg.Key?.Equals(key) == true);

            if (entry != null)
            {
                entry.Value = value;
            }
            else
            {
                hashTable[hash].AddLast(new HashEntry<TKey, TValue> { Value = value, Key = key });
            }
        }

        public bool Find(TKey key)
        {
            var hash = Math.Abs(key.GetHashCode() % hashTable.Length);

            return hashTable[hash]?.FirstOrDefault(arg => arg.Key?.Equals(key) == true) != null;
        }

        public TValue Get(TKey key)
        {
            var hash = Math.Abs(key.GetHashCode() % hashTable.Length);

            var entry = hashTable[hash]?.FirstOrDefault(arg => arg.Key?.Equals(key) == true);

            if (entry is null)
            {
                throw new ArgumentException($"Hash table contains no entry with key {key}");
            }

            return entry.Value;
        }

        public void Delete(TKey key)
        {
            var hash = Math.Abs(key.GetHashCode() % hashTable.Length);

            var entry = hashTable[hash]?.FirstOrDefault(arg => arg.Key?.Equals(key) == true);

            if (entry != null)
            {
                hashTable[hash].Remove(entry);
            }
        }
    }
}
