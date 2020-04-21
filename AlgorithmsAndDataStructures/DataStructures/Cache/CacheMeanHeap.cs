using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.DataStructures.Cache
{
    public class CacheMeanHeap
    {
        private CacheMeanHeapEntry[] heap;
        private Dictionary<int, int> indexes = new Dictionary<int, int>();
        private int nextElement;

        public CacheMeanHeap(int capacity)
        {
            heap = new CacheMeanHeapEntry[capacity + 1];
            nextElement = 1;
        }

        public void RemoveTop()
        {
            var top = heap[1];
            indexes.Remove(top.Key);
            heap[1] = null;
            nextElement--;

            if (nextElement > 1)
            {
                var newtop = heap[nextElement];
                heap[1] = newtop;
                indexes[newtop.Key] = 1;
                heap[nextElement] = null;
                Sink(1);
            }
        }

        internal string GetValue(int key)
        {
            if (indexes.ContainsKey(key))
            {
                var value = heap[indexes[key]].Value;
                heap[indexes[key]].IncrementFrequency();
                Sink(indexes[key]);

                return value;
            }

            return null;
        }

        private void Sink(int index)
        {
            int rightChildIndex = index * 2 + 1;
            int leftChildIndex = index * 2;
            int swapChildIndex = leftChildIndex;

            if (leftChildIndex >= nextElement)
            {
                return;
            }

            if (rightChildIndex < nextElement)
            {
                swapChildIndex = heap[rightChildIndex].Frequency < heap[leftChildIndex].Frequency ? rightChildIndex : leftChildIndex;
            }

            if (heap[swapChildIndex].Frequency < heap[index].Frequency)
            {
                var tmp = heap[index];
                
                heap[index] = heap[swapChildIndex];
                indexes[heap[index].Key] = index;
                
                heap[swapChildIndex] = tmp;
                indexes[heap[swapChildIndex].Key] = swapChildIndex;
                
                Sink(swapChildIndex);
            }
        }

        public void Insert(CacheMeanHeapEntry entry)
        {
            if (indexes.ContainsKey(entry.Key))
            {
                var index = indexes[entry.Key];

                heap[index].SetValue(entry.Value);
                heap[index].IncrementFrequency();

                Sink(index);

                return;
            }

            if (nextElement == heap.Length)
            {
                throw new InvalidOperationException();
            }

            heap[nextElement] = entry;
            indexes[entry.Key] = nextElement;
            nextElement++;
            Swim(nextElement - 1);
        }

        private void Swim(int index)
        {
            if (index <= 1)
            {
                return;
            }

            var parent = index / 2;

            if (heap[index].Frequency < heap[parent].Frequency)
            {
                var tmp = heap[index];

                heap[index] = heap[parent];
                indexes[heap[index].Key] = index;

                heap[parent] = tmp;
                indexes[heap[parent].Key] = parent;

                Swim(parent);
            }
        }
    }
}
