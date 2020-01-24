namespace AlgorithmsAndDataStructures.Algorithms.Sorting
{
    public class CombSort : ISortingAlgorithm
    {
        public void Sort(int[] target)
        {
            var swapped = true;
            var gap = target.Length;

            while (gap > 1 || swapped)
            {
                if (gap > 1)
                {
                    gap = (int)(gap / 1.3);
                }

                var j = 0;
                swapped = false;
                while (j + gap < target.Length)
                {
                    if (target[j] > target[j + gap])
                    {
                        SortUtilities.Swap(target, j, j + gap);
                        swapped = true;
                    }
                    j++;
                }
            }
        }
    }
}
