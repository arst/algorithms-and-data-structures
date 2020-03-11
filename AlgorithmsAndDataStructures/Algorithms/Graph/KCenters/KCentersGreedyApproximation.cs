using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.KCenters
{
    public class KCentersGreedyApproximation
    {
        public int[] GetKCenters(int[][] graph, int centers)
        {
            var result = new int[centers];
            var foundCentersCount = 0;
            result[foundCentersCount] = 0;
            foundCentersCount++;
            

            while (foundCentersCount < result.Length)
            {
                var maxDisatanceFromCentersVerticeIndex = -1;
                var maxDisatanceFromCentersVertice = int.MinValue;

                for (int i = 0; i < graph.Length; i++)
                {
                    if (result.Contains(i))
                    {
                        continue;
                    }

                    var minDistance = int.MaxValue;
                    for (int c = 0; c < foundCentersCount; c++)
                    {
                        if (c == i)
                        {
                            continue;
                        }

                        if (graph[c][i] < minDistance)
                        {
                            minDistance = graph[c][i];
                        }
                    }

                    if (maxDisatanceFromCentersVerticeIndex == -1 || maxDisatanceFromCentersVertice < minDistance)
                    {
                        maxDisatanceFromCentersVerticeIndex = i;
                        maxDisatanceFromCentersVertice = minDistance;
                    }
                }

                result[foundCentersCount] = maxDisatanceFromCentersVerticeIndex;
                foundCentersCount++;
            }

            return result;
        }
    }
}
