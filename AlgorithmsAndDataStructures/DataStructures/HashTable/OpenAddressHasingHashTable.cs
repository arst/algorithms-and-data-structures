using System;

namespace AlgorithmsAndDataStructures.DataStructures.HashTable
{
    public class OpenAddressHasingHashTable<TKey, TValue>
    {
        private int counter;
        private HashEntry<TKey, TValue>[] hashTable;
        private static HashEntry<TKey, TValue> DeletedEntry = new HashEntry<TKey, TValue>
        {
            Key = default,
            Value = default
        };

        public OpenAddressHasingHashTable(int initialCapacity = 8)
        {
            hashTable = new HashEntry<TKey, TValue>[initialCapacity];
            counter = 0;
        }

        public void Add(TKey key, TValue value)
        {
            if (counter == hashTable.Length && !Find(key))
            {
                throw new ArgumentException("Hash table is full.");
            }

            var initialIndex = Math.Abs(key.GetHashCode() % hashTable.Length);
            var currentIndex = initialIndex;

            do
            {
                if (hashTable[currentIndex] == DeletedEntry || hashTable[currentIndex] == null)
                {
                    hashTable[currentIndex] = new HashEntry<TKey, TValue>
                    { 
                        Value = value,
                        Key = key,
                    };
                    break;
                }

                if (hashTable[currentIndex].Key.Equals(key))
                {
                    hashTable[currentIndex].Value = value;
                    break;
                }

                currentIndex = (currentIndex + 1) % hashTable.Length;
            } while (currentIndex != initialIndex);

            counter += 1;
        }

        public bool Find(TKey key)
        {
            var initialIndex = Math.Abs(key.GetHashCode() % hashTable.Length);
            var currentIndex = initialIndex;

            do
            {
                if(hashTable[currentIndex] == null)
                {
                    return false;
                }

                if (hashTable[currentIndex].Key?.Equals(key) == true)
                {
                    return true;
                }

                currentIndex = (currentIndex + 1) % hashTable.Length;

            } while (currentIndex != initialIndex);

            return false;            
        }

        public TValue Get(TKey key)
        {
            var initialIndex = Math.Abs(key.GetHashCode() % hashTable.Length);
            var currentIndex = initialIndex;

            do
            {
                if (hashTable[currentIndex] == null)
                {
                    throw new ArgumentException($"Hash table has no entry with key {key}.");
                }

                if (hashTable[currentIndex].Key?.Equals(key) == true)
                {
                    return hashTable[currentIndex].Value;
                }

                currentIndex = (currentIndex + 1) % hashTable.Length;

            } while (currentIndex != initialIndex);

            throw new ArgumentException($"Hash table has no entry with key {key}."); ;
        }

        public void Delete(TKey key)
        {
            var initialIndex = Math.Abs(key.GetHashCode() % hashTable.Length);
            var currentIndex = initialIndex;

            do
            {
                if (hashTable[currentIndex] == null)
                {
                    // Nothing to delete.
                    return;
                }

                if (hashTable[currentIndex] != DeletedEntry && hashTable[currentIndex].Key.Equals(key))
                {
                    hashTable[currentIndex] = DeletedEntry;
                    counter -= 1;
                    return;
                }

                currentIndex = (currentIndex + 1) % hashTable.Length;

            } while (currentIndex != initialIndex);
        }
    }
}
