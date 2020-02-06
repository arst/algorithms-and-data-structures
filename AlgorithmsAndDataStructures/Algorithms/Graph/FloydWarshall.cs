namespace AlgorithmsAndDataStructures.Algorithms.Graph
{
    public class FloydWarshall
    {
        public (int[][] disatnces, int[][] path) MinDistances(WeightedGraphNode[] graph)
        {
            var disatnces = new int[graph.Length][];
            var path = new int[graph.Length][];

            for (int i = 0; i < disatnces.Length; i++)
            {
                disatnces[i] = new int[graph.Length];
                path[i] = new int[graph.Length];
                disatnces[i][i] = 0;
                path[i][i] = i;

                for (int j = 0; j < disatnces[i].Length; j++)
                {
                    if (j != i)
                    {
                        disatnces[i][j] = int.MaxValue / 2; // int.MaxValue will give us an overflow inside main loop
                    }
                }
            }

            for (int i = 0; i < graph.Length; i++)
            {
                var vertex = graph[i];

                for (int j = 0; j < vertex.Edges.Count; j++)
                {
                    disatnces[i][vertex.Edges[j].To] = vertex.Edges[j].Weight;
                    path[i][vertex.Edges[j].To] = i;
                }
            }

            for (int k = 0; k < disatnces.Length; k++)
            {
                for (int i = 0; i < disatnces.Length; i++)
                {
                    for (int j = 0; j < disatnces.Length; j++)
                    {
                        if (disatnces[i][j] > disatnces[i][k] + disatnces[k][j])
                        {
                            disatnces[i][j] = disatnces[i][k] + disatnces[k][j];
                            path[i][j] = k;
                        }
                    }
                }
            }

            return (disatnces, path);
        }
    }
}
