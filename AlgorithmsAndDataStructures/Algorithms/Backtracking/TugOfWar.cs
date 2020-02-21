using System;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.Backtracking
{
    public class TugOfWar
    {
        public (int[] left, int[] right) GetTug(int[] set)
        {
            var leftTugLength = set.Length % 2 == 1 ? (set.Length - 1) / 2 : set.Length / 2;
            var visited = new bool[set.Length];
            var result = new int[leftTugLength];

            var hasTug = GetLeftTug(set, visited, result, 0);

            return (hasTug ? result : Array.Empty<int>(), hasTug ? GetRightTug(set, visited, leftTugLength) : Array.Empty<int>());
        }

        private bool GetLeftTug(int[] set, bool[] included, int[] result, int resultCounter)
        {
            if (resultCounter >= result.Length)
            {
                var rightTug = GetRightTug(set, included, result.Length);

                return rightTug.Sum() == result.Sum();
            }

            var firstNonIncluded = GetNotIncludedIndex(set, included, 0);

            while (firstNonIncluded != -1)
            {
                result[resultCounter] = set[firstNonIncluded];
                resultCounter++;
                included[firstNonIncluded] = true;
                var hasTug = GetLeftTug(set, included, result, resultCounter);

                if (hasTug)
                {
                    return true;
                }
                else
                {
                    included[firstNonIncluded] = false;
                    resultCounter--;
                    firstNonIncluded = GetNotIncludedIndex(set, included, firstNonIncluded + 1);
                }
            }

            return false;
        }

        private int[] GetRightTug(int[] set, bool[] included, int leftTugLength)
        {
            var result = new int[set.Length - leftTugLength];
            var resultPointer = 0;

            for (int i = 0; i < set.Length; i++)
            {
                if (!included[i])
                {
                    result[resultPointer] = set[i];
                    resultPointer++;
                }
            }

            return result;
        }

        private int GetNotIncludedIndex(int[] set, bool[] included, int startingPosition)
        {
            for (int i = startingPosition; i < set.Length; i++)
            {
                if (!included[i])
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
