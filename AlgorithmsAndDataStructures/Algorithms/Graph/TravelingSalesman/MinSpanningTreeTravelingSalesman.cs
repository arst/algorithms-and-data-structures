using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.TravelingSalesman
{
    public class MinSpanningTreeTravelingSalesman
    {
        public int Travel(int[][] graph)
        {
            const int startingCity = 0;
            var edges = new List<Tuple<int, int, int>>();
            var minimumSpanningTree = new List<Tuple<int, int, int>>();
            var spanningTree = new HashSet<int>();
            var minimumSpanningTreeWeight = 0;

            spanningTree.Add(startingCity); 

            //collect all edges for Prim's algorithm
            for (int i = 0; i < graph.Length; i++)
            {
                for (int j = 0; j < graph.Length; j++)
                {
                    if (graph[i][j] > 0)
                    {
                        // Item1 - From, Item2 - To, Item3 - Weight
                        edges.Add(new Tuple<int, int, int>(i, j, graph[i][j]));
                    }
                }
            }
            // Construct MST using Prim's algorithm
            while (spanningTree.Count < graph.Length)
            {
                Tuple<int, int, int> minEdge = null;

                for (int i = 0; i < edges.Count; i++)
                {
                    if ((minEdge == null || minEdge.Item3 > edges[i].Item3) && spanningTree.Contains(edges[i].Item1) && !spanningTree.Contains(edges[i].Item2))
                    {
                        minEdge = edges[i];
                    }
                }

                edges.Remove(minEdge);
                minimumSpanningTree.Add(minEdge);
                minimumSpanningTreeWeight += minEdge.Item3;
                spanningTree.Add(minEdge.Item2);
            }

            //Construct a graph with MST tree edges only
            var minSpanningTreeGraph = new Tuple<int, List<int>>[graph.Length];

            for (int i = 0; i < minimumSpanningTree.Count; i++)
            {
                var edge = minimumSpanningTree[i];

                minSpanningTreeGraph[edge.Item1] = minSpanningTreeGraph[edge.Item1] ?? new Tuple<int, List<int>>(edge.Item1, new List<int>());
                minSpanningTreeGraph[edge.Item2] = minSpanningTreeGraph[edge.Item2] ?? new Tuple<int, List<int>>(edge.Item2, new List<int>());

                minSpanningTreeGraph[edge.Item1].Item2.Add(edge.Item2);
                minSpanningTreeGraph[edge.Item2].Item2.Add(edge.Item1);
            }

            // Make DFS traversal of constructed graph
            var path = new List<int>();
            var visited = new bool[graph.Length];
            DFS(minSpanningTreeGraph, path, visited, startingCity);
            var weight = 0;

            // Calculate path weight
            for (int i = 0; i < path.Count - 1; i++)
            {
                weight += graph[path[i]][path[i + 1]];
            }

            // We should return to the starting city 
            return weight + graph[path.Last()][startingCity];
        }

        private void DFS(Tuple<int, List<int>>[] minSpanningTreeGraph, List<int> path, bool[] visited, int current)
        {
            visited[current] = true;
            path.Add(current);

            List<int> adjacentVertices = minSpanningTreeGraph[current].Item2;
            for (int i = 0; i < adjacentVertices.Count; i++)
            {
                if (!visited[adjacentVertices[i]])
                {
                    DFS(minSpanningTreeGraph, path, visited, adjacentVertices[i]);
                }
            }
        }
    }
}
