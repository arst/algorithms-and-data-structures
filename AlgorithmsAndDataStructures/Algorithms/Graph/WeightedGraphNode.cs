using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Graph
{
    public class WeightedGraphNode
    {
        public List<WeightedGraphNodeEdge> Edges { get; set; } = new List<WeightedGraphNodeEdge>();
    }
}
