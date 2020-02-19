using AlgorithmsAndDataStructures.Algorithms.Graph.Common;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.Misc
{
    public class TransitiveClosureFloydWarshall
    {
        public int[][] GetReachabilityMatrix(WeightedGraphNode[] graph)
        {
            var reachabilityMatrix = new bool[graph.Length][];

            for (int i = 0; i < reachabilityMatrix.Length; i++)
            {
                reachabilityMatrix[i] = new bool[graph.Length];
            }

            
            for (int i = 0; i < graph.Length; i++)
            {
                for (int j = 0; j < graph.Length; j++)
                {
                    for (int k = 0; k < graph.Length; k++)
                    {

                    }
                }
            }
        }
    }
}
