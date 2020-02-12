using AlgorithmsAndDataStructures.Algorithms.Graph.Common;

namespace AlgorithmsAndDataStructures.Algorithms.Graph
{
    public class HeapNode
    {
        public int IndexInOriginalGraph { get; set; }

        public int Weight { get; set; }

        public WeightedGraphNode Node { get; set; }
    }
}
