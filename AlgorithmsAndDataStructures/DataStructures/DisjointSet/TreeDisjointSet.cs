namespace AlgorithmsAndDataStructures.DataStructures.DisjointSet
{
    public class TreeDisjointSet : IDisjointSet
    {
        private int[] set;

        public TreeDisjointSet(int size)
        {
            set = new int[size];

            for (var i = 0; i < size; i++)
            {
                set[i] = i;
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

            set[bRoot] = aRoot;
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
