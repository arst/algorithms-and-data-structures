using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlgorithmsAndDataStructures.Algorithms.Graph.MinimumSpanningTree.BoruvkasAlgorithm
{
    public class BoruvkasAlgorithm
    {
        public int GetMinimumSpanningTreeWeightParallel(int vertices, List<Edge> edges)
        {
            Subset[] subsets = new Subset[vertices];
            Edge[] cheapest = new Edge[vertices];

            for (int v = 0; v < vertices; v++)
            {
                subsets[v] = new Subset { Root = v, Weight = 0 };
                cheapest[v] = null;
            }

            int numTrees = vertices;
            int mstWeight = 0;

            while (numTrees > 1)
            {
                Parallel.For(0, vertices, v =>
                {
                    cheapest[v] = null;
                });

                Parallel.ForEach(edges, (edge) =>
                {
                    int set1 = Find(subsets, edge.Source);
                    int set2 = Find(subsets, edge.Destination);

                    if (set1 != set2)
                    {
                        lock (cheapest)
                        {
                            if (cheapest[set1] == null || cheapest[set1].Weight > edge.Weight)
                                cheapest[set1] = edge;

                            if (cheapest[set2] == null || cheapest[set2].Weight > edge.Weight)
                                cheapest[set2] = edge;
                        }
                    }
                });

                for (int i = 0; i < vertices; i++)
                {
                    Edge edge = cheapest[i];
                    if (edge != null)
                    {
                        int set1 = Find(subsets, edge.Source);
                        int set2 = Find(subsets, edge.Destination);

                        if (set1 != set2)
                        {
                            mstWeight += edge.Weight;
                            Union(subsets, set1, set2);
                            numTrees--;
                        }
                    }
                }
            }

            return mstWeight;
        }

        public int GetMinimumSpanningTreeWeight(int vertices, List<Edge> edges)
        {
            var subsets = new Subset[vertices];
            var cheapest = new Edge[vertices];

            // Initialize each vertex as a separate subset and set the cheapest edge to null
            for (int v = 0; v < vertices; v++)
            {
                subsets[v] = new Subset { Root = v, Weight = 0 };
                cheapest[v] = null;
            }

            // Start with each vertex as a separate tree in the forest
            int numTrees = vertices;
            int mstWeight = 0; // This will hold the total weight of the MST

            // Continue until there is only one tree left in the forest (the MST)
            while (numTrees > 1)
            {
                // Reset the cheapest edge for each subset for this round
                for (int v = 0; v < vertices; v++)
                    cheapest[v] = null;

                // For each edge, find the subsets of the vertices it connects
                foreach (var edge in edges)
                {
                    int set1 = Find(subsets, edge.Source);
                    int set2 = Find(subsets, edge.Destination);

                    // If the vertices are already in the same subset, ignore this edge
                    if (set1 == set2)
                        continue;

                    // If this edge is cheaper than the current cheapest for set1, update it
                    if (cheapest[set1] == null || cheapest[set1].Weight > edge.Weight)
                        cheapest[set1] = edge;

                    // If this edge is cheaper than the current cheapest for set2, update it
                    if (cheapest[set2] == null || cheapest[set2].Weight > edge.Weight)
                        cheapest[set2] = edge;
                }

                // For each vertex, check if the cheapest edge can be added to the MST
                for (int i = 0; i < vertices; i++)
                {
                    Edge edge = cheapest[i];

                    // If there is a cheapest edge for this subset(safe check for disconnected graphs and already connected components)
                    if (edge != null)
                    {
                        int set1 = Find(subsets, edge.Source);
                        int set2 = Find(subsets, edge.Destination);

                        // If the edge connects two different trees, add it to the MST
                        if (set1 != set2)
                        {
                            mstWeight += edge.Weight; // Add the weight of the edge to the total MST weight

                            Union(subsets, set1, set2); // Merge the two trees into one
                            numTrees--; // Decrease the number of trees in the forest
                        }
                    }
                }
            }

            // Return the total weight of the MST
            return mstWeight;
        }

        // Helper method to find the root of the subset that element i is part of
        private static int Find(Subset[] subsets, int i)
        {
            // Path compression: update the root of the subset to be the root of the parent
            if (subsets[i].Root != i)
                subsets[i].Root = Find(subsets, subsets[i].Root);

            return subsets[i].Root;
        }

        // Helper method to union (merge) two subsets into one
        private static void Union(Subset[] subsets, int x, int y)
        {
            int xroot = Find(subsets, x);
            int yroot = Find(subsets, y);

            // Attach the smaller rank tree under the root of the higher rank tree
            if (subsets[xroot].Weight < subsets[yroot].Weight)
                subsets[xroot].Root = yroot;
            else if (subsets[xroot].Weight > subsets[yroot].Weight)
                subsets[yroot].Root = xroot;
            else
            {
                // If ranks are the same, make one as root and increment its rank by one
                subsets[yroot].Root = xroot;
                subsets[xroot].Weight++;
            }
        }
    }
}
