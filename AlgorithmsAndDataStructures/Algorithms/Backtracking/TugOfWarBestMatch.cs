using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.Backtracking;

public class TugOfWarBestMatch
{
#pragma warning disable CA1822 // Mark members as static
    public (int[] left, int[] right) GetTug(int[] set)
#pragma warning restore CA1822 // Mark members as static
    {
        if (set is null)
            return (Array.Empty<int>(), Array.Empty<int>());

        var leftTugLength = set.Length % 2 == 1 ? (set.Length - 1) / 2 : set.Length / 2;
        var visited = new bool[set.Length];
        var solution = new bool[set.Length];
        GetLeftTug(set, visited, 0, int.MaxValue, solution, leftTugLength);
        return (GetLeftTug(set, solution, leftTugLength), GetRightTug(set, solution, leftTugLength));
    }

    private static int GetLeftTug(IReadOnlyList<int> set, bool[] included, int leftTugParticipants, int difference,
        IList<bool> solution, int leftTugLength)
    {
        if (leftTugParticipants >= leftTugLength)
        {
            var rightTug = GetRightTug(set, included, leftTugLength);
            var leftTug = GetLeftTug(set, included, leftTugLength);

            if (Math.Abs(rightTug.Sum() - leftTug.Sum()) <= difference)
            {
                for (var i = 0; i < included.Length; i++)
                    solution[i] = included[i];
                return Math.Abs(rightTug.Sum() - leftTug.Sum());
            }

            return difference;
        }

        var firstNonIncluded = GetNotIncludedIndex(set, included, 0);

        while (firstNonIncluded != -1 && leftTugParticipants < leftTugLength)
        {
            leftTugParticipants++;
            included[firstNonIncluded] = true;
            difference = GetLeftTug(set, included, leftTugParticipants, difference, solution, leftTugLength);

            included[firstNonIncluded] = false;
            leftTugParticipants--;
            firstNonIncluded = GetNotIncludedIndex(set, included, firstNonIncluded + 1);
        }

        return difference;
    }

    private static int[] GetRightTug(IReadOnlyList<int> set, IReadOnlyList<bool> included, int leftTugLength)
    {
        var result = new int[set.Count - leftTugLength];
        var resultPointer = 0;

        for (var i = 0; i < set.Count; i++)
            if (!included[i])
            {
                result[resultPointer] = set[i];
                resultPointer++;
            }

        return result;
    }

    private static int[] GetLeftTug(IReadOnlyList<int> set, IReadOnlyList<bool> included, int leftTugLength)
    {
        var result = new int[leftTugLength];
        var resultPointer = 0;

        for (var i = 0; i < set.Count; i++)
            if (included[i])
            {
                result[resultPointer] = set[i];
                resultPointer++;
            }

        return result;
    }

    private static int GetNotIncludedIndex(IReadOnlyCollection<int> set, IReadOnlyList<bool> included,
        int startingPosition)
    {
        for (var i = startingPosition; i < set.Count; i++)
            if (!included[i])
                return i;

        return -1;
    }
}