﻿using System;

namespace AlgorithmsAndDataStructures.DataStructures.BinaryHeaps;

public class MaxBinaryHeap<T> : BinaryHeap<T> where T : IComparable<T>
{
    public MaxBinaryHeap(int maxCapacity = 8)
        : base(maxCapacity)
    {
    }

    protected override bool ShouldSwap(int current, int target)
    {
        return Heap[current].CompareTo(Heap[target]) > 0;
    }

    protected override bool ShouldNotSwap(int current, int target)
    {
        return Heap[current].CompareTo(Heap[target]) < 0;
    }

    protected override int GetSwapChildIndex(int rightChildIndex, int leftChildIndex)
    {
        return Heap[leftChildIndex].CompareTo(Heap[rightChildIndex]) < 0 ? rightChildIndex : leftChildIndex;
    }
}