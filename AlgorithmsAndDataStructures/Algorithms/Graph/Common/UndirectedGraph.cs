using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.Common
{
    public class UndirectedGraph
    {
        private List<int>[] adj;

        public UndirectedGraph(int size)
        {
            adj = new List<int>[size];
            for (int i = 0; i < size; ++i)
                adj[i] = new List<int>();
        }

        void Connect(int nodeA, int nodeB)
        {
            adj[nodeA].Add(nodeB);
            adj[nodeB].Add(nodeA); 
        }

        public List<int>[] Vertices()
        {
            return adj.ToArray();
        }
    }
}
