using AlgorithmsAndDataStructures.Algorithms.Graph.Common;
using System;

namespace AlgorithmsAndDataStructures.Algorithms.Graph
{
    /*
    Negative weighted edges allowed: NO
    Complexity: o(n * log n + m * log n), where n - edges, m - vertices
    Application: Most famous - digital services to find shortest path on the maps.
   */
    public class DijkstraHeapified
    {
        public (int, int[] path) MinDistance(WeightedGraphVertex[] graph, int from, int to)
        {
            var heap = new HeapNode[graph.Length];
            var heapEnd = heap.Length;
            var mapping = new int[graph.Length];
            var path = new int[graph.Length];
            PopulateHeap(graph, from, heap, mapping);

            while (heapEnd > 0 && heap[0].Weight < int.MaxValue)
            {
                var current = heap[0];

                foreach (var edge in current.Vertex.Edges)
                {
                    int heapIndexForDestinationNode = mapping[edge.To];

                    int heapIndexForCurrentlyInspectedNode = mapping[current.IndexInOriginalGraph];

                    var destinationNodeCurentWeight = heap[heapIndexForDestinationNode].Weight;
                    var destinationNodeProposedWeight = heap[heapIndexForCurrentlyInspectedNode].Weight + edge.Weight;

                    if (destinationNodeCurentWeight > destinationNodeProposedWeight)
                    {
                        heap[heapIndexForDestinationNode].Weight = destinationNodeProposedWeight;
                        path[edge.To] = current.IndexInOriginalGraph;

                        if (heapIndexForDestinationNode < heapEnd)
                        {
                            RestoreHeap(heap, mapping, heapIndexForDestinationNode);
                        }
                    }
                }

                var temp = heap[0];
                heap[0] = heap[heapEnd - 1];
                heap[heapEnd - 1] = temp;
                mapping[temp.IndexInOriginalGraph] = heapEnd - 1;
                mapping[heap[0].IndexInOriginalGraph] = 0;
                heapEnd--;
                Sink(heap, 0, mapping, heapEnd);
            }

            return (heap[mapping[to]].Weight, path);
        }

        private static void PopulateHeap(WeightedGraphVertex[] graph, int from, HeapNode[] heap, int[] mapping)
        {
            for (int i = 0; i < heap.Length; i++)
            {
                heap[i] = new HeapNode()
                {
                    IndexInOriginalGraph = i,
                    Weight = i == from ? 0 : int.MaxValue,
                    Vertex = graph[i]
                };
                mapping[i] = i;
            }
        }

        private static void Sink(HeapNode[] heap, int current, int[] mapping, int heapEnd)
        {
            var leftChild = current * 2 + 1;
            var rightChild = current * 2 + 2;
            var smallestIndexInSubtree = current;

            if (leftChild < heapEnd && heap[leftChild].Weight < heap[smallestIndexInSubtree].Weight)
            {
                smallestIndexInSubtree = leftChild;
            }
            if (rightChild < heapEnd && heap[rightChild].Weight < heap[smallestIndexInSubtree].Weight)
            {
                smallestIndexInSubtree = rightChild;
            }

            if (smallestIndexInSubtree != current)
            {
                Swap(heap, mapping, smallestIndexInSubtree, current);
            }
        }

        private static void RestoreHeap(HeapNode[] heap, int[] mapping, int i)
        {
            if (i == 0)
            {
                return;
            }

            var parent = i % 2 == 0 ? (i / 2) - 1 : i / 2;

            if (heap[parent].Weight > heap[i].Weight)
            {
                Swap(heap, mapping, i, parent);

                RestoreHeap(heap, mapping, parent);
            }
        }

        private static void Swap(HeapNode[] heap, int[] mapping, int from, int to)
        {
            var temp = heap[to];
            heap[to] = heap[from];
            heap[from] = temp;
            mapping[heap[from].IndexInOriginalGraph] = from;
            mapping[heap[to].IndexInOriginalGraph] = to;
        }
    }
}
