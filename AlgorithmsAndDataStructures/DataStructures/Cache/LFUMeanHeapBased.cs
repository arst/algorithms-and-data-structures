using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.DataStructures.Cache
{
    public class LFUMeanHeapBased
    {
        private CacheMeanHeap heap;
        private int entriesCount;
        private int capacity;

        public LFUMeanHeapBased(int capacity)
        {
            heap = new CacheMeanHeap(capacity);
            entriesCount = 0;
            this.capacity = capacity;
        }

        public void Add(int key, string value)
        {
            if (entriesCount == capacity)
            {
                heap.RemoveTop();
                entriesCount--;
            }

            var entry = new CacheMeanHeapEntry(key, value);
            heap.Insert(entry);
            entriesCount++;
        }

        public string Get(int key)
        {
            return heap.GetValue(key); ;
        }
    }
}
