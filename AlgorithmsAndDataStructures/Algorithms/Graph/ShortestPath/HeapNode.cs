using AlgorithmsAndDataStructures.Algorithms.Graph.Common;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.ShortestPath
{
    internal sealed class HeapNode
    {
        internal int IndexInOriginalGraph { get; set; }

        internal int Weight { get; set; }

        internal WeightedGraphVertex Vertex { get; set; }
    }
}
