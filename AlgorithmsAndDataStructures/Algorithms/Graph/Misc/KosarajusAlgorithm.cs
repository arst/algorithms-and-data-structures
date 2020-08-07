using AlgorithmsAndDataStructures.Algorithms.Graph.Common;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.Misc
{
    public class KosarajusAlgorithm
    {
        public bool IsConnected(WeightedGraphVertex[] graph)
        {
            var visited = new bool[graph.Length];

            DFS(graph, 0, visited);

            for (int i = 0; i < visited.Length; i++)
            {
                if (!visited[i])
                {
                    return false;
                }
            }

            var transposedGraph = GetTransposed(graph);
            var transposedVisited = new bool[graph.Length];

            DFS(transposedGraph, 0, transposedVisited);

            for (int i = 0; i < transposedVisited.Length; i++)
            {
                if (!transposedVisited[i])
                {
                    return false;
                }
            }

            return true;
        }

        private void DFS(WeightedGraphVertex[] graph, int currentVertice, bool[] visited)
        {
            visited[currentVertice] = true;

            for (int i = 0; i < graph[currentVertice].Edges.Count; i++)
            {
                int neigbhor = graph[currentVertice].Edges[i].To;

                if (!visited[neigbhor])
                {
                    DFS(graph, neigbhor, visited);
                }
            }
        }

        private WeightedGraphVertex[] GetTransposed(WeightedGraphVertex[] graph)
        {
            var result = new WeightedGraphVertex[graph.Length];

            for (int i = 0; i < graph.Length; i++)
            {
                result[i] = result[i] == null ? new WeightedGraphVertex() : result[i];

                for (int j = 0; j < graph[i].Edges.Count; j++)
                {
                    var from = graph[i].Edges[j].To;

                    if (result[from] == null)
                    {
                        result[from] = new WeightedGraphVertex();
                    }

                    result[from].Edges.Add(new WeightedGraphNodeEdge()
                    {
                        From = from,
                        To = graph[i].Edges[j].From,
                        Weight = graph[i].Edges[j].Weight
                    });
                }
            }

            return result;
        }
    }
}
