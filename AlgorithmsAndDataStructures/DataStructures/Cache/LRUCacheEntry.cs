using System;

namespace AlgorithmsAndDataStructures.DataStructures.Cache
{
    public class LRUCacheEntry
    {
        private int key;
        private string value;

        public LRUCacheEntry Previous { get; set; }
        public LRUCacheEntry Next { get; set; }

        public string Value => value;

        public int Key => key;

        public LRUCacheEntry(int key, string value)
        {
            this.key = key;
            this.value = value;
        }

        internal void UpdateValue(string value)
        {
            this.value = value;
        }
    }
}
