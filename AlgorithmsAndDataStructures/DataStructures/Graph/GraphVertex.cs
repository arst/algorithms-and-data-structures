using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.DataStructures.Graph
{
    public class GraphVertex<T>
    {
        public T Value { get; set; }

#pragma warning disable CA2227 // Collection properties should be read only
        public List<int> AdjacentVertices { get; set; } = new List<int>();
#pragma warning restore CA2227 // Collection properties should be read only
    }
}
