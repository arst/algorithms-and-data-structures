using System;

namespace AlgorithmsAndDataStructures.DataStructures.DisjointSet
{
    public class WeightedTreeDisjointSet : IDisjointSet
    {
        private int[] set;
        private int[] weight;

        public WeightedTreeDisjointSet(int size)
        {
            set = new int[size];
            weight = new int[size];

            for (var i = 0; i < size; i++)
            {
                set[i] = i;
            }

            for (var i = 0; i < size; i++)
            {
                weight[i] = 1;
            }
        }

        public bool Connected(int a, int b)
        {
            return FindRoot(a) == FindRoot(b);
        }

        public void Union(int a, int b)
        {
            var aRoot = FindRoot(a);
            var bRoot = FindRoot(b);

            if (weight[aRoot] >= weight[bRoot])
            {
                set[bRoot] = aRoot;
                weight[aRoot] = weight[aRoot] + weight[bRoot];
            }
            else
            {
                set[aRoot] = bRoot;
                weight[bRoot] = weight[aRoot] + weight[bRoot];
            }
        }

        private int FindRoot(int a)
        {
            var current = a;

            while (current != set[current])
            {
                current = set[set[current]];
            }

            return current;
        }
    }
}
