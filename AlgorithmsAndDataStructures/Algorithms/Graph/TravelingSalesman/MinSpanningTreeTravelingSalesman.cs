using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.TravelingSalesman
{
    public class MinSpanningTreeTravelingSalesman
    {
        public int Travel(int[][] graph)
        {
            var startingCity = 0;
            var edges = new List<Tuple<int, int, int>>();
            var minimumSpanningTree = new List<Tuple<int, int, int>>();
            var spanningTree = new HashSet<int>();
            var minimumSpanningTreeWeight = 0;

            spanningTree.Add(startingCity);

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

            return 0;
        }
    }
}
