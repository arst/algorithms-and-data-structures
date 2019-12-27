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
            var currentIndex = index + 1;

            var result = 0;

            while (currentIndex > 0)
            {
                result += binaryIndexedTree[currentIndex];
                currentIndex = currentIndex - (currentIndex & -currentIndex);
            }

            return result;
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
