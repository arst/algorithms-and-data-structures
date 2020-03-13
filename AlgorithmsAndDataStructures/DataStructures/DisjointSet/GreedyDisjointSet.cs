namespace AlgorithmsAndDataStructures.DataStructures.DisjointSet
{
    public class GreedyDisjointSet : IDisjointSet
    {
        private int[] set;

        public GreedyDisjointSet(int size)
        {
            set = new int[size];

            for (int i = 0; i < size; i++)
            {
                set[i] = i;
            }
        }

        public void Union(int a, int b)
        {
            var aSet = set[a];
            var bSet = set[b];

            for (int i = 0; i < set.Length; i++)
            {
                if (set[i] == bSet)
                {
                    set[i] = aSet;
                }
            }
        }

        public bool Connected(int a, int b)
        {
            return set[a] == set[b];
        }
    }
}
