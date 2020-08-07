using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.Common
{
    public class WeightedGraphVertex
    {
#pragma warning disable CA2227 // Collection properties should be read only
        public List<WeightedGraphNodeEdge> Edges { get; set; } = new List<WeightedGraphNodeEdge>();
#pragma warning restore CA2227 // Collection properties should be read only
    }
}
