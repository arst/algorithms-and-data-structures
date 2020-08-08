using System;
using System.Linq;

namespace AlgorithmsAndDataStructures.DataStructures.BinaryHeaps
{
    public abstract class BinaryHeap<T> where T: IComparable<T> 
    {
#pragma warning disable CA1051 // Do not declare visible instance fields
        protected T[] Heap;
#pragma warning restore CA1051 // Do not declare visible instance fields
        private int nextElementPointer = 1;

        public int Size => nextElementPointer - 1;

        public T[] GetHeap()
        {
            return Heap.Skip(1).ToArray().Clone() as T[];
        }

        protected BinaryHeap(int maxCapacity = 8)
        {
            Heap = new T[maxCapacity + 1];
        }

        protected abstract bool ShouldSwap(int current, int target);

        protected abstract bool ShouldNotSwap(int current, int target);

        protected abstract int GetSwapChildIndex(int rightChildIndex, int leftChildIndex);

        public void Insert(T value)
        {
            if (nextElementPointer == Heap.Length)
            {
#pragma warning disable CA1303 // Do not pass literals as localized parameters
                throw new ArgumentException("Heap is full");
#pragma warning restore CA1303 // Do not pass literals as localized parameters
            }

            Heap[nextElementPointer] = value;
            Swim(nextElementPointer);
            nextElementPointer++;
        }

        private void Swim(int nextElementPointer)
        {
            var current = nextElementPointer;
            while (current > 1)
            {
                var parentIndex = current / 2;
                if (Heap[current].CompareTo(Heap[parentIndex]) == 0)
                {
                    break;
                }

                if (ShouldNotSwap(current, parentIndex))
                {
                    break;
                }

                if (ShouldSwap(current, parentIndex))
                {
                    var tmp = Heap[parentIndex];
                    Heap[parentIndex] = Heap[current];
                    Heap[current] = tmp;
                    current = parentIndex;
                }
            }
        }

        public T GetTop()
        {
            if (nextElementPointer - 1 == 0)
            {
#pragma warning disable CA1303 // Do not pass literals as localized parameters
                throw new ArgumentException("Heap is empty");
#pragma warning restore CA1303 // Do not pass literals as localized parameters
            }

            var result = Heap[1];
            Heap[1] = Heap[nextElementPointer - 1];
            Heap[nextElementPointer - 1] = default;
            nextElementPointer--;

            Sink(1);

            return result;
        }

        private void Sink(int index)
        {
            var rightChildIndex = index * 2 + 1;
            var leftChildIndex = index * 2;
            var swapChildIndex = leftChildIndex;

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
                var tmp = Heap[index];

                Heap[index] = Heap[swapChildIndex];
                Heap[swapChildIndex] = tmp;

                Sink(swapChildIndex);
            }
        }
    }
}
