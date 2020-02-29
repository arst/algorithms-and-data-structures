using AlgorithmsAndDataStructures.Algorithms.Graph.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.Misc
{
    public class KargersAlgorithmForMinimumCut
    {
        public int MinCut(UndirectedGraph originalGraph, int samplingCount)
        {
            var originalVertices = originalGraph.Vertices();
            var minCuts = new List<int>(samplingCount);

            // It's a randomized algorithm so we should run a few itterations to achieve the results as close as possible to the optimum.
            while (samplingCount > 0)
            {
                var vertices = new Dictionary<int, List<int>>();
                // Copy all vertices to a new dictionary with indexes as a key and vadjacent vertices as values.
                for (int j = 0; j < originalVertices.Length; j++)
                {
                    var original = originalVertices[j];
                    vertices.Add(j, new List<int>(original));
                }
                // Keep contracting ddges until only two left.
                while (vertices.Count > 2)
                {
                    // Pick random edge.
                    var randomEdge = GetRandomEdge(vertices);

                    // Iterate over adjacent vertices of 'to' vertice. We are going to conflate it with 'from' vertice.
                    for (int i = 0; i < vertices[randomEdge.to].Count; i++)
                    {
                        var vertice = vertices[randomEdge.to][i];

                        // To avoid self-loops. They aren't allowed according to Karger's algorithm.
                        if (vertice != randomEdge.from)
                        {
                            vertices[randomEdge.from].Add(vertice);
                        }
                        // Remove edge to conflated vertice from adjacent vertice.
                        vertices[vertice].Remove(randomEdge.to);
                        // Add edge to 'from' vertice since 'to' vertice was conflated into it.
                        if (vertice != randomEdge.from)
                        {
                            vertices[vertice].Add(randomEdge.from);
                        }
                    }
                    // We don't need sconflated vertice anymore.
                    vertices.Remove(randomEdge.to);
                }

                // Count of vertices from the first node is the min cut. 
                minCuts.Add(vertices.First().Value.Count);
                samplingCount--;
            }

            return minCuts.Min();
        }

        private (int from, int to) GetRandomEdge(Dictionary<int, List<int>> vertices)
        {
            // There is should be a better way to pick random edge.
            var r = new Random();
            var from = -1;
            var to = -1;

            while (from < 0 || to < 0)
            {
                from = r.Next(vertices.Count);
                if (vertices.Keys.Any(arg => arg == from))
                {
                    to = r.Next(vertices[from].Count);

                    if (vertices[from][to] != from)
                    {
                        to = vertices[from][to];
                    }
                }
            }

            return (from, to);
        }
    }
}
