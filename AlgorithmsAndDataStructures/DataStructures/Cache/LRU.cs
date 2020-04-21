using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.DataStructures.Cache
{
    public class LRU
    {
        private Dictionary<int, LRUCacheEntry> values;
        private readonly int capacity;
        private int entriesCount;
        private LRUDoubleLinkedList list;

        public LRU(int capacity)
        {
            values = new Dictionary<int, LRUCacheEntry>();
            this.capacity = capacity;
            entriesCount = 0;
            list = new LRUDoubleLinkedList();
        }

        public void Add(int key, string value)
        {
            if (values.ContainsKey(key))
            {
                values[key].UpdateValue(value);
            }

            if (entriesCount == capacity)
            {
                var removedEntry = list.RemoveTail();
                values.Remove(removedEntry.Key);
                entriesCount--;
            }

            values.Add(key, list.InsertToHead(key, value));

            entriesCount++;
        }

        public string Get(int key)
        {
            if (!values.ContainsKey(key))
            {
                return null;
            }

            var entry = values[key];
            if (entriesCount > 1)
            {
                list.MoveToHead(entry);
            }

            return entry.Value;
        }
    }
}
