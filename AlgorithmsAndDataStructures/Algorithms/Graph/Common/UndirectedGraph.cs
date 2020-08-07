using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.Common
{
    public class UndirectedGraph
    {
        private readonly List<int>[] adjacentVertices;

        public UndirectedGraph(int size)
        {
            adjacentVertices = new List<int>[size];

            for (var i = 0; i < size; ++i)
                adjacentVertices[i] = new List<int>();
        }

        public void Connect(int nodeA, int nodeB)
        {
            adjacentVertices[nodeA].Add(nodeB);
            adjacentVertices[nodeB].Add(nodeA); 
        }

        public List<int>[] Vertices()
        {
            return adjacentVertices.ToArray();
        }
    }
}
