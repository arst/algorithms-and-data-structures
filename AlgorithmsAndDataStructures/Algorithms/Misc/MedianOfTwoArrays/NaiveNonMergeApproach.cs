namespace AlgorithmsAndDataStructures.Algorithms.Misc.MedianOfTwoArrays
{
    public class NaiveNonMergeApproach
    {
        public float GetMedian(int[] left, int[] right)
        {
            var leftPointer = 0;
            var rightPointer = 0;
            var resultPointer = 0;
            var smallerMdiaNumber = 0;
            var biggerMedianNumber = 0;

            var result = new int[left.Length + right.Length];

            while (leftPointer < left.Length && rightPointer < right.Length)
            {
                if (left[leftPointer] < right[rightPointer])
                {
                    result[resultPointer] = left[leftPointer];
                    leftPointer++;
                }
                else
                {
                    result[resultPointer] = right[rightPointer];
                    rightPointer++;
                }

                if (leftPointer + rightPointer == (result.Length / 2))
                {
                    smallerMdiaNumber = result[resultPointer];
                }
                if (leftPointer + rightPointer == (result.Length / 2) + 1)
                {
                    biggerMedianNumber = result[resultPointer];
                    break;
                }

                resultPointer++;
            }

            return (float)(smallerMdiaNumber + biggerMedianNumber) / 2;
        }
    }
}
