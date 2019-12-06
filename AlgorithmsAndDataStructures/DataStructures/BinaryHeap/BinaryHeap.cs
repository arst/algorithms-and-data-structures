using System;

namespace AlgorithmsAndDataStructures.DataStructures.BinaryHeap
{
    public class BinaryHeap<T> where T: IComparable<T> 
    {
        private T[] heap;
        private int nextElementPointer = 1;

        public BinaryHeap(int maxCapacity = 8)
        {
            heap = new T[maxCapacity];
        }

        public void Insert(T value)
        {
            if (nextElementPointer == heap.Length)
            {
                throw new ArgumentException("Heap is full");
            }

            heap[nextElementPointer] = value;
            Swim(nextElementPointer);
        }

        private void Swim(int nextElementPointer)
        {
            var current = nextElementPointer;
            while (current > 0)
            {
                if (heap[current].CompareTo(heap[current / 2]) == 0)
                {
                    break;
                }

                if (heap[current].CompareTo(heap[current / 2]) < 0)
                {
                    break;
                }

                if (heap[current].CompareTo(heap[current / 2]) > 0)
                {
                    var tmp = heap[current / 2];
                    heap[current / 2] = heap[current];
                    heap[current] = tmp;
                    current = current / 2;
                }
            }
        }

        public void GetTop()
        {
            var result = heap[1];
            heap[1] = heap[nextElementPointer - 1];
            nextElementPointer--;

            Sink(1);
        }

        private void Sink(int v)
        {
            var current = v;
            // Change this to some defined case.

            while (true)
            {
                var minChildValue = heap[current * 2].CompareTo(heap[current * 2 + 1]) > 0 ? heap[current * 2 + 1] : heap[current * 2];

                if (heap[current].CompareTo(minChildValue) > 0)
                {
                    var tmp = heap[current];

                    if (heap[current * 2].Equals(minChildValue))
                    {
                        heap[current] = heap[current * 2];
                        heap[current * 2] = tmp;
                        current = current * 2;
                    }
                    else if (heap[current * 2 + 1].Equals(minChildValue))
                    {
                        heap[current] = heap[current * 2 +1];
                        heap[current * 2 + 1] = tmp;

                        current = current * 2 + 1;
                    }
                }
            }
        }
    }
}
