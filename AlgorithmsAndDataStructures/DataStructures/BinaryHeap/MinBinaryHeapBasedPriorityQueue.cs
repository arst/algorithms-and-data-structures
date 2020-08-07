using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.DataStructures.BinaryHeap
{
    public class MinBinaryHeapBasedPriorityQueue<T> : IProducerConsumerCollection<T> where T: IComparable<T>
    {
        private readonly object lockObject = new object();

        private readonly MinBinaryHeap<T> heap;

        public int Count => heap.GetHeap().Length;

        public bool IsSynchronized => true;

        public object SyncRoot => lockObject;

        public MinBinaryHeapBasedPriorityQueue(int initialCapacity = 8)
        {
            this.heap = new MinBinaryHeap<T>(initialCapacity);
        }

        public void CopyTo(T[] array, int index)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            IEnumerator<T> result;

            lock (lockObject)
            {
                var heapCopy = heap.GetHeap();
                Array.Sort(heapCopy);
                result = heapCopy.AsEnumerable().GetEnumerator();
            }

            return result;
        }

        public T[] ToArray()
        {
            var heapCopy = heap.GetHeap();
            Array.Sort(heapCopy);
            return heapCopy;
        }

        public bool TryAdd(T item)
        {
            try
            {
                lock (lockObject)
                {
                    heap.Insert(item);
                }
            }
            // Probably not the best idea to controll execution like this.
            catch (ArgumentException)
            {
                return false;
            }

            return true;
        }

        public bool TryTake(out T item)
        {
            try
            {
                lock (lockObject)
                {
                    item = heap.GetTop();
                }
            }
            // Probably not the best idea to controll execution like this.
            catch (ArgumentException)
            {
                item = default;
                return false;
            }

            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            IEnumerator result;

            lock (lockObject)
            {
                result = heap.GetHeap().GetEnumerator();
            }

            return result;
        }
    }
}
