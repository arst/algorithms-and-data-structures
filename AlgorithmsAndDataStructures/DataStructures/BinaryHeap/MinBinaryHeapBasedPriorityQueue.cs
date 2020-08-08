using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.DataStructures.BinaryHeap
{
#pragma warning disable CA1010 // Collections should implement generic interface
#pragma warning disable CA1710 // Identifiers should have correct suffix
    public class MinBinaryHeapBasedPriorityQueue<T> : IProducerConsumerCollection<T> where T: IComparable<T>
#pragma warning restore CA1710 // Identifiers should have correct suffix
#pragma warning restore CA1010 // Collections should implement generic interface
    {
        private readonly MinBinaryHeap<T> heap;

        public int Count
        {
            get
            {
                lock (SyncRoot)
                {
                    return heap?.GetHeap()?.Length ?? 0;
                }
            }
        }

        public bool IsSynchronized => true;

        public object SyncRoot { get; } = new object();

        public MinBinaryHeapBasedPriorityQueue(int initialCapacity = 8)
        {
            heap = new MinBinaryHeap<T>(initialCapacity);
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

            lock (SyncRoot)
            {
                var heapCopy = heap.GetHeap();
                Array.Sort(heapCopy);
#pragma warning disable HAA0401 // Possible allocation of reference type enumerator
                result = heapCopy.AsEnumerable().GetEnumerator();
#pragma warning restore HAA0401 // Possible allocation of reference type enumerator
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
                lock (SyncRoot)
                {
                    heap.Insert(item);
                }
            }
            // Probably not the best idea to control execution like this.
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
                lock (SyncRoot)
                {
                    item = heap.GetTop();
                }
            }
            // Probably not the best idea to control execution like this.
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

            lock (SyncRoot)
            {
                result = heap.GetHeap().GetEnumerator();
            }

            return result;
        }
    }
}
