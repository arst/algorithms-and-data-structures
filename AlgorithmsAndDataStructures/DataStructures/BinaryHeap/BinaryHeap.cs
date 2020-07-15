using System;
using System.Linq;

namespace AlgorithmsAndDataStructures.DataStructures.BinaryHeap
{
    public abstract class BinaryHeap<T> where T: IComparable<T> 
    {
        protected T[] heap;
        private int nextElementPointer = 1;

        public int Size => nextElementPointer - 1;

        public T[] GetHeap()
        {
            return heap.Skip(1).ToArray().Clone() as T[];
        }

        public BinaryHeap(int maxCapacity = 8)
        {
            heap = new T[maxCapacity];
        }

        protected abstract bool ShouldSwap(int current, int target);

        protected abstract bool ShouldNotSwap(int current, int target);

        protected abstract int GetSwapChildIndex(int rightChildIndex, int leftChildIndex);

        public void Insert(T value)
        {
            if (nextElementPointer == heap.Length)
            {
                throw new ArgumentException("Heap is full");
            }

            heap[nextElementPointer] = value;
            Swim(nextElementPointer);
            nextElementPointer++;
        }

        private void Swim(int nextElementPointer)
        {
            var current = nextElementPointer;
            while (current > 1)
            {
                int parentIndex = current / 2;
                if (heap[current].CompareTo(heap[parentIndex]) == 0)
                {
                    break;
                }

                if (ShouldNotSwap(current, parentIndex))
                {
                    break;
                }

                if (ShouldSwap(current, parentIndex))
                {
                    var tmp = heap[parentIndex];
                    heap[parentIndex] = heap[current];
                    heap[current] = tmp;
                    current = parentIndex;
                }
            }
        }

        public T GetTop()
        {
            if (nextElementPointer - 1 == 0)
            {
                throw new ArgumentException("Heap is empty");
            }

            var result = heap[1];
            heap[1] = heap[nextElementPointer - 1];
            heap[nextElementPointer - 1] = default;
            nextElementPointer--;

            Sink(1);

            return result;
        }

        private void Sink(int index)
        {
            int rightChildIndex = index * 2 + 1;
            int leftChildIndex = index * 2;
            int swapChildIndex = leftChildIndex;

            if (leftChildIndex >= nextElementPointer)
            {
                return;
            }

            if (rightChildIndex < nextElementPointer)
            {
                swapChildIndex = GetSwapChildIndex(rightChildIndex, leftChildIndex);
            }

            if (!ShouldSwap(index, swapChildIndex))
            {
                var tmp = heap[index];

                heap[index] = heap[swapChildIndex];
                heap[swapChildIndex] = tmp;

                Sink(swapChildIndex);
            }
        }
    }
}
