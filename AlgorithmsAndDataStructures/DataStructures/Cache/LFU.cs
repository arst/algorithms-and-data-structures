using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.DataStructures.Cache
{
    public class LFU
    {
        private Dictionary<int, CacheEntry> values;
        private Dictionary<int, CacheDoubleLinkedList> frequencies;
        private Dictionary<CacheEntry, int> nodeFrequencies;
        private int minFrequency;
        private int capacity;
        private int entriesCount;
        private const int defaultFrequency = 1;

        public LFU(int capacity)
        {
            values = new Dictionary<int, CacheEntry>();
            frequencies = new Dictionary<int, CacheDoubleLinkedList>();
            nodeFrequencies = new Dictionary<CacheEntry, int>();
            minFrequency = int.MaxValue;
            this.capacity = capacity;
            entriesCount = 0;
        }

        public void Add(int key, string value)
        {
            if (values.ContainsKey(key))
            {
                values[key].UpdateValue(value);
                PromoteEntry(values[key]);
                return;
            }

            if (entriesCount == capacity)
            {
                var evictedEntry = frequencies[minFrequency].RemoveTail();
                values.Remove(evictedEntry.Key);

                if (frequencies[minFrequency].IsEmpty)
                {
                    frequencies.Remove(minFrequency);
                }

                entriesCount--;
            }

            if (!frequencies.ContainsKey(defaultFrequency))
            {
                frequencies[defaultFrequency] = new CacheDoubleLinkedList();
            }

            var newEntry = new CacheEntry(key, value);
            frequencies[defaultFrequency].InsertToHead(newEntry);
            values[key] = newEntry;
            nodeFrequencies[newEntry] = defaultFrequency;
            minFrequency = defaultFrequency;
            entriesCount++;
        }

        public string Get(int key)
        {
            if (!values.ContainsKey(key))
            {
                return null;
            }

            var entry = values[key];

            PromoteEntry(entry);

            return entry.Value;
        }

        private void PromoteEntry(CacheEntry cacheEntry)
        {
            var currentFrequency = nodeFrequencies[cacheEntry];
            frequencies[currentFrequency].Remove(cacheEntry);

            if (frequencies[currentFrequency].IsEmpty)
            {
                frequencies.Remove(currentFrequency);
            }

            var newFrequency = currentFrequency++;

            if (!frequencies.ContainsKey(newFrequency))
            {
                frequencies[newFrequency] = new CacheDoubleLinkedList();
            }

            frequencies[newFrequency].InsertToHead(cacheEntry);
            nodeFrequencies[cacheEntry] = newFrequency;
        }
    }
}
