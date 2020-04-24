namespace AlgorithmsAndDataStructures.Algorithms.Misc.MedianOfTwoArrays
{
    public class NaiveApproach : IMediaOfTwoArraysAlgorithm
    {
        public float GetMedian(int[] left, int[] right)
        {
            var leftPointer = 0;
            var rightPointer = 0;
            var resultPointer = 0;

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

                resultPointer++;
            }

            UpFillArray(result, left, resultPointer, leftPointer);
            UpFillArray(result, right, resultPointer, rightPointer);

            return (float)(result[(result.Length / 2) - 1] + result[result.Length / 2]) / 2;
        }

        private void UpFillArray(int[] result, int[] source, int resultIndex, int sourceIndex)
        {
            while (sourceIndex < source.Length)
            {
                result[resultIndex] = source[sourceIndex];
                sourceIndex++;
                resultIndex++;
            }
        }
    }
}
