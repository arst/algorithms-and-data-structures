using AlgorithmsAndDataStructures.Algorithms.Graph.Common;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.Misc
{
    public class TransitiveClosureFloydWarshall
    {
        public bool[][] GetReachabilityMatrix(WeightedGraphVertex[] graph)
        {
            var reachabilityMatrix = new bool[graph.Length][];

            for (var i = 0; i < reachabilityMatrix.Length; i++)
            {
                reachabilityMatrix[i] = new bool[graph.Length];
                reachabilityMatrix[i][i] = true;

                for (var j = 0; j < graph[i].Edges.Count; j++)
                {
                    var edge = graph[i].Edges[j];
                    reachabilityMatrix[i][edge.To] = true;
                }
            }

            
            for (var i = 0; i < graph.Length; i++)
            {
                for (var j = 0; j < graph.Length; j++)
                {
                    for (var k = 0; k < graph.Length; k++)
                    {
                        var isReachableThroughCurrentlyInspectedVertice = reachabilityMatrix[i][k] && reachabilityMatrix[k][j];
                        if (isReachableThroughCurrentlyInspectedVertice)
                        {
                            reachabilityMatrix[i][j] = isReachableThroughCurrentlyInspectedVertice;
                        }
                    }
                }
            }

            return reachabilityMatrix;
        }
    }
}
