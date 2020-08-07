using AlgorithmsAndDataStructures.Algorithms.Graph.Common;
using AlgorithmsAndDataStructures.Algorithms.Graph.Misc;
using AlgorithmsAndDataStructures.DataStructures.DisjointSet;
using AlgorithmsAndDataStructures.DataStructures.Graph;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.MinimumSpanningTree
{
    public class KruskalMinimumSpanningTreeWithDisjointSet
    {

        // Complexity is O(ElogE) or O(ElogV):
        // E * log E - to sort vertices
        // log V - find connectivity with union find
        // overall E*logE + logV
        // Without a disjoint set check for cycle takes linear time.
        public int GetMinimumSpanningTreeWeight(WeightedGraphVertex[] graph)
        {
            var minimumSpanningTreeWeight = 0;
            var minimumSpanningTree = new List<WeightedGraphNodeEdge>();
            var spanningTree = new GraphNode<int>[graph.Length];
            var disjointSet = new WeightedTreeCoompressedPathDisjoinSet(graph.Length);

            for (int i = 0; i < spanningTree.Length; i++)
            {
                spanningTree[i] = new GraphNode<int>();
            }

            var spanningTreeSize = 0;
            var currentEdgeIndex = 0;

            var edges = graph.SelectMany(arg => arg.Edges).OrderBy(arg => arg.Weight).ToArray();


            while (spanningTreeSize < graph.Length - 1)
            {
                var currentEdge = edges[currentEdgeIndex];
                
                spanningTree[currentEdge.From].AdjacentNodes.Add(currentEdge.To);

                if (!disjointSet.Connected(currentEdge.From, currentEdge.To))
                {
                    spanningTreeSize++;
                    minimumSpanningTreeWeight += currentEdge.Weight;
                    minimumSpanningTree.Add(currentEdge);
                    disjointSet.Union(currentEdge.From, currentEdge.To);
                }
                else
                {
                    spanningTree[currentEdge.From].AdjacentNodes.Remove(currentEdge.To);
                }

                currentEdgeIndex++;
            }

            return minimumSpanningTreeWeight;
        }
    }
}
