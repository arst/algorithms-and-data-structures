using System;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.Backtracking
{
    public class TugOfWarBestMatch
    {
        public (int[] left, int[] right) GetTug(int[] set)
        {
            var leftTugLength = set.Length % 2 == 1 ? (set.Length - 1) / 2 : set.Length / 2;
            var visited = new bool[set.Length];
            var solution = new bool[set.Length];

            GetLeftTug(set, visited, 0, int.MaxValue, solution, leftTugLength);

            return (GetLeftTug(set, solution, leftTugLength) , GetRightTug(set, solution, leftTugLength));
        }

        private int GetLeftTug(int[] set, bool[] included, int resultCounter, int difference, bool[] solution, int leftTugLength)
        {
            if (resultCounter >= leftTugLength)
            {
                var rightTug = GetRightTug(set, included, leftTugLength);
                var leftTug = GetLeftTug(set, included, leftTugLength);

                if (Math.Abs(rightTug.Sum() - leftTug.Sum()) <= difference)
                {
                    for (int i = 0; i < included.Length; i++)
                    {
                        solution[i] = included[i];
                    }

                    return Math.Abs(rightTug.Sum() - leftTug.Sum());
                }

                return difference;
            }

            var firstNonIncluded = GetNotIncludedIndex(set, included, 0);

            while (firstNonIncluded != -1 && resultCounter < leftTugLength)
            {
                resultCounter++;
                included[firstNonIncluded] = true;
                difference = GetLeftTug(set, included, resultCounter, difference, solution, leftTugLength);
                
                included[firstNonIncluded] = false;
                resultCounter--;
                firstNonIncluded = GetNotIncludedIndex(set, included, firstNonIncluded + 1);
            }

            return difference;
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

        private int[] GetLeftTug(int[] set, bool[] included, int leftTugLength)
        {
            var result = new int[leftTugLength];
            var resultPointer = 0;

            for (int i = 0; i < set.Length; i++)
            {
                if (included[i])
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
