namespace AlgorithmsAndDataStructures.DataStructures.BinaryIndexedTree
{
    public class BinaryIndexedTree
    {
        public static BinaryIndexedTree FromArray(int[] input)
        {
            var result = new BinaryIndexedTree(input.Length + 1);
            var index = 0;

            foreach (var item in input)
            {
                result.SetValue(index, item);
                index++;
            }

            return result;
        }

        private int treeSize;
        private int[] binaryIndexedTree;

        public BinaryIndexedTree(int treeSisze = 100)
        {
            this.treeSize = treeSisze;
            this.binaryIndexedTree = new int[treeSize];
        }

        public int GetSum(int index)
        {
            // Since range in Fenwick tree doesn't include last element
            var currentIndex = index + 1;

            var result = 0;

            while (currentIndex > 0)
            {
                result += binaryIndexedTree[currentIndex];
                //TRICK: parent of any node can be obtain by removing the last set bit from the binary representation of that node.
                currentIndex = currentIndex - (currentIndex & -currentIndex);
            }

            return result;
        }

        public int GetSum(int start, int end)
        {
            return GetSum(end) - GetSum(start - 1);
        }

        public void SetValue(int index, int value)
        {
            var currentIndex = index + 1;

            while (currentIndex < treeSize)
            {
                binaryIndexedTree[currentIndex] += value;

                currentIndex += (currentIndex & -currentIndex);
            }
        }


    }
}
