using AlgorithmsAndDataStructures.Algorithms.Graph.Common;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.LongestPath
{
    public class CriticalPath
    {
        public int GetCriticalPath(WeightedGraphNode[] graph)
        {
            var modifiedGraph = AppendDummyNodes(graph);

            var topologicalSort = SortTopologically(modifiedGraph);
            var criticalPathValue = CalculateCriticalPath(modifiedGraph, topologicalSort);

            return criticalPathValue[criticalPathValue.Length - 1];
        }

        private static int[] CalculateCriticalPath(WeightedGraphNode[] modifiedGraph, Stack<int> topologicalSort)
        {
            var criticalPathValue = new int[modifiedGraph.Length];
            var crtiticalPath = new int[modifiedGraph.Length];

            while (topologicalSort.Count > 0)
            {
                var currentNodeIndex = topologicalSort.Pop();

                foreach (var edge in modifiedGraph[currentNodeIndex].Edges)
                {
                    int criticalPathThroughCurrentVerticeValue = criticalPathValue[currentNodeIndex] + edge.Weight;
                    if (criticalPathThroughCurrentVerticeValue > criticalPathValue[edge.To])
                    {
                        criticalPathValue[edge.To] = criticalPathThroughCurrentVerticeValue;
                        crtiticalPath[edge.To] = currentNodeIndex;
                    }
                }
            }

            return criticalPathValue;
        }

        private static WeightedGraphNode[] AppendDummyNodes(WeightedGraphNode[] graph)
        {
            var (hasInboundEdges, hasOutboundEdges) = GetEdgeNodes(graph);

            var sourceNode = new WeightedGraphNode();
            var targetNode = new WeightedGraphNode();

            for (int i = 0; i < hasInboundEdges.Length; i++)
            {
                if (!hasInboundEdges[i])
                {
                    sourceNode.Edges.Add(new WeightedGraphNodeEdge() { To = i });
                }

                if (!hasOutboundEdges[i])
                {
                    graph[i].Edges.Add(new WeightedGraphNodeEdge() { To = graph.Length + 1, From = i });
                }
            }

            var modifiedGraph = graph.ToList();
            modifiedGraph.Add(sourceNode);
            modifiedGraph.Add(targetNode);


            return modifiedGraph.ToArray();
        }

        private static Stack<int> SortTopologically(WeightedGraphNode[] graph)
        {
            var topologicalSort = new Stack<int>();
            var visited = new bool[graph.Length];

            // TODO: Probably it's better to return it from AppendDummyNodes anmd pass to this method as a paremter. This one looks a little bit "magical".
            int sourceNodeIndex = graph.Length - 2;

            SortTopologically(currentNode: sourceNodeIndex, graph, topologicalSort, visited);

            return topologicalSort;
        }

        private static void SortTopologically(int currentNode, WeightedGraphNode[] graph, Stack<int> topologicalSort, bool[] visited)
        {
            visited[currentNode] = true;

            foreach (var edge in graph[currentNode].Edges)
            {
                if (!visited[edge.To])
                {
                    SortTopologically(edge.To, graph, topologicalSort, visited);
                }
            }

            topologicalSort.Push(currentNode);
        }

        private static (bool[] HasInboundEdges, bool[] HasOutboundEdges) GetEdgeNodes(WeightedGraphNode[] graph)
        {
            var hasInboundEdges = new bool[graph.Length];
            var hasOutboundEdges = new bool[graph.Length];

            foreach (var vertice in graph)
            {
                foreach (var edge in vertice.Edges)
                {
                    hasInboundEdges[edge.To] = true;
                    hasOutboundEdges[edge.From] = true;
                }
            }

            return (HasInboundEdges: hasInboundEdges, HasOutboundEdges: hasOutboundEdges);
        }
    }
}
