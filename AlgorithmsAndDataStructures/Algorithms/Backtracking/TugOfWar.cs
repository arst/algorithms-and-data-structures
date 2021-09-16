using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.Backtracking
{
    public class TugOfWar
    {
#pragma warning disable CA1822 // Mark members as static
        public (int[] left, int[] right) GetTug(int[] set)
#pragma warning restore CA1822 // Mark members as static
        {
            if (set is null)
                return (Array.Empty<int>(), Array.Empty<int>());
            var leftTugLength = set.Length % 2 == 1 ? (set.Length - 1) / 2 : set.Length / 2;
            var visited = new bool[set.Length];
            var result = new int[leftTugLength];
            var hasTug = GetLeftTug(set, visited, result, 0);
            return (hasTug ? result : Array.Empty<int>(), hasTug ? GetRightTug(set, visited, leftTugLength) : Array.Empty<int>());
        }

        private static bool GetLeftTug(IReadOnlyList<int> set, bool[] included, IList<int> result, int leftTugParticipants)
        {
            if (leftTugParticipants >= result.Count)
            {
                var rightTug = GetRightTug(set, included, result.Count);
                return rightTug.Sum() == result.Sum();
            }

            var firstNonIncludedIndex = GetNotIncludedIndex(set, included, 0);

            while (firstNonIncludedIndex != -1)
            {
                result[leftTugParticipants] = set[firstNonIncludedIndex];
                leftTugParticipants++;
                included[firstNonIncludedIndex] = true;
                var hasTug = GetLeftTug(set, included, result, leftTugParticipants);
                if (hasTug)
                    return true;
                included[firstNonIncludedIndex] = false;
                leftTugParticipants--;
                firstNonIncludedIndex = GetNotIncludedIndex(set, included, firstNonIncludedIndex + 1);
            }
            return false;
        }

        private static int[] GetRightTug(IReadOnlyList<int> set, IReadOnlyList<bool> included, int leftTugLength)
        {
            var result = new int[set.Count - leftTugLength];
            var resultPointer = 0;
            for (var i = 0; i < set.Count; i++)
            {
                if (!included[i])
                {
                    result[resultPointer] = set[i];
                    resultPointer++;
                }
            }
            return result;
        }

        private static int GetNotIncludedIndex(IReadOnlyCollection<int> set, IReadOnlyList<bool> included, int startingPosition)
        {
            for (var i = startingPosition; i < set.Count; i++)
            {
                if (!included[i])
                    return i;
            }
            return -1;
        }
    }
}
