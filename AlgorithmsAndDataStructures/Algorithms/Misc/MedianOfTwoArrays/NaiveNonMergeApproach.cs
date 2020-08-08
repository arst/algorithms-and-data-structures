namespace AlgorithmsAndDataStructures.Algorithms.Misc.MedianOfTwoArrays
{
    public class NaiveNonMergeApproach : IMediaOfTwoArraysAlgorithm
    {
        public float GetMedian(int[] left, int[] right)
        {
            if (left is null || right is null)
            {
                return default;
            }

            var leftPointer = 0;
            var rightPointer = 0;
            var resultPointer = 0;
            var smallerMedianNumber = 0;
            var biggerMedianNumber = 0;

            var result = new int[left.Length + right.Length];

            while (leftPointer < left.Length || rightPointer < right.Length)
            {
                var isInsideBorders = leftPointer < left.Length && rightPointer < right.Length;


                if (isInsideBorders)
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
                }
                else
                {
                    if (leftPointer < left.Length)
                    {
                        result[resultPointer] = left[leftPointer];
                        leftPointer++;
                    }
                    else
                    {
                        result[resultPointer] = right[rightPointer];
                        rightPointer++;
                    }
                }

                if (leftPointer + rightPointer == (result.Length / 2))
                {
                    smallerMedianNumber = result[resultPointer];
                }
                if (leftPointer + rightPointer == (result.Length / 2) + 1)
                {
                    biggerMedianNumber = result[resultPointer];
                    break;
                }

                resultPointer++;
            }

            return (float)(smallerMedianNumber + biggerMedianNumber) / 2;
        }
    }
}
