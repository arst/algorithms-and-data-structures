using AlgorithmsAndDataStructures.Algorithms.Graph.Common;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.Misc
{
    public class EulerianPath
    {
        public (bool hasEulerianCycle, bool hasEulerianPath) IsEulerian(UndirectedGraph graph)
        {
            if (graph.Vertices().Length < 2)
            {
                return (true, true);
            }

            var vertices = graph.Vertices();
            var visited = new bool[vertices.Length];


            // Check if all non-zero degree vertices are connected
            var nonZeroDegreeVertice = 0;

            for (var i = 0; i < vertices.Length; i++)
            {
                // We need to start from non-zero degree vertice to traverse non-zero degree vertices
                if (vertices[i].Count > 0)
                {
                    nonZeroDegreeVertice = i;
                    break;
                }
                //There is no non-zero degree vertices, graph is disconnected
                if (i == vertices.Length - 1)
                {
                    return (false, false);
                }
            }

            DFS(vertices, visited, nonZeroDegreeVertice);

            for (var i = 0; i < vertices.Length; i++)
            {
                // If some of the vertices with non-zero degree are not visited during DFS, then graph is not Eulerian
                if (!visited[i] && vertices[i].Count > 0)
                {
                    return (false, false);
                }
            }

            //Count vertices with odd degree, in Eulerian graph there are 0 or 2 vertices with odd degree. It is impossible to have 1 odd degree vertice in undirected graph.
            var odd = 0;

            for (var i = 0; i < vertices.Length; i++)
            {
                if (vertices[i].Count % 2 != 0)
                {
                    odd++;
                }
            }

            if (odd > 2)
            {
                return (false, false);
            }

            // if there are 2 vertices with odd degree then it is a semi-eulerian(has only Eulerian path) graph, if all vertices are even then it is a full-eulerian(has Eulerian cycle) graph
            return (odd == 0, odd == 2);
        }

        private static void DFS(System.Collections.Generic.List<int>[] vertices, bool[] visited, int currentVertice)
        {
            visited[currentVertice] = true;

            for (var i = 0; i < vertices[currentVertice].Count; i++)
            {
                if (!visited[vertices[currentVertice][i]])
                {
                    DFS(vertices, visited, vertices[currentVertice][i]);
                }
            }
        }
    }
}
