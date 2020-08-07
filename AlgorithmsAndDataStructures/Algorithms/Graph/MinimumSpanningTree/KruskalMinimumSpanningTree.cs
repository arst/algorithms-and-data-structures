using AlgorithmsAndDataStructures.Algorithms.Graph.Common;
using AlgorithmsAndDataStructures.Algorithms.Graph.Misc;
using AlgorithmsAndDataStructures.DataStructures.Graph;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.MinimumSpanningTree
{
    public class KruskalMinimumSpanningTree
    {
        public int GetMinimumSpanningTreeWeight(WeightedGraphVertex[] graph)
        {
            var minimumSpanningTreeWeight = 0;
            var minimumSpanningTree = new List<WeightedGraphNodeEdge>();
            var spanningTree = new GraphNode<int>[graph.Length];

            for (var i = 0; i < spanningTree.Length; i++)
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

                if (!IsCyclic(spanningTree))
                {
                    spanningTreeSize++;
                    minimumSpanningTreeWeight += currentEdge.Weight;
                    minimumSpanningTree.Add(currentEdge);
                }
                else
                {
                    spanningTree[currentEdge.From].AdjacentNodes.Remove(currentEdge.To);
                }

                currentEdgeIndex++;
            }

            return minimumSpanningTreeWeight;
        }

        private bool IsCyclic(GraphNode<int>[] spanningTree)
        {
            return new CycleDetection().IsCyclic(spanningTree);
        }
    }
}
