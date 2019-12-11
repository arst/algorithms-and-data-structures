using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.DataStructures.Graph
{
    public class GraphNode<T>
    {
        public T Value { get; set; }

        public List<int> AdjacentNodes { get; set; } = new List<int>();
    }
}
