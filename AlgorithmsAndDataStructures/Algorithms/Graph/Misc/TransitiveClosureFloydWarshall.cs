using System;
using AlgorithmsAndDataStructures.Algorithms.Graph.Common;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.Misc
{
    public class TransitiveClosureFloydWarshall
    {
#pragma warning disable CA1822 // Mark members as static
        public bool[][] GetReachabilityMatrix(WeightedGraphVertex[] graph)
#pragma warning restore CA1822 // Mark members as static
        {
            if (graph is null)
            {
                return Array.Empty<bool[]>();
            }

            var reachabillityMatrix = new bool[graph.Length][];

            for (var i = 0; i < reachabillityMatrix.Length; i++)
            {
                reachabillityMatrix[i] = new bool[graph.Length];
                reachabillityMatrix[i][i] = true;

                for (var j = 0; j < graph[i].Edges.Count; j++)
                {
                    var edge = graph[i].Edges[j];
                    reachabillityMatrix[i][edge.To] = true;
                }
            }

            
            for (var i = 0; i < graph.Length; i++)
            {
                for (var j = 0; j < graph.Length; j++)
                {
                    for (var k = 0; k < graph.Length; k++)
                    {
                        var isReachableThroughCurrentlyInspectedVertex = reachabillityMatrix[i][k] && reachabillityMatrix[k][j];
                        if (isReachableThroughCurrentlyInspectedVertex)
                        {
                            reachabillityMatrix[i][j] = true;
                        }
                    }
                }
            }

            return reachabillityMatrix;
        }
    }
}
