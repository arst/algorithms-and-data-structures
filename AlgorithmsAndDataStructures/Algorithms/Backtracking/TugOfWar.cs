using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.Backtracking;

/// <summary>
/// Solves the Tug of War problem - dividing a set of numbers into two subsets with equal sums
/// and minimal size difference (at most 1).
/// </summary>
public class TugOfWar
{
    /// <summary>
    /// Finds two subsets with equal sums from the given set.
    /// </summary>
    /// <param name="set">Input array of numbers</param>
    /// <returns>Two arrays representing left and right subsets with equal sums. 
    /// Returns empty arrays if no solution exists.</returns>
    public (int[] left, int[] right) GetTug(int[] set)
    {
        if (set == null || set.Length == 0)
        {
            return (Array.Empty<int>(), Array.Empty<int>());
        }

        // For odd-length sets, left side gets (n-1)/2 elements, right side gets (n+1)/2
        var leftTugLength = set.Length % 2 == 1 ? (set.Length - 1) / 2 : set.Length / 2;
        var visited = new bool[set.Length];
        var leftTug = new int[leftTugLength];

        return TryFindTug(set, visited, leftTug)
            ? (leftTug, GetRightTug(set, visited))
            : (Array.Empty<int>(), Array.Empty<int>());
    }

    private static bool TryFindTug(IReadOnlyList<int> set, bool[] included, int[] leftTug, int leftTugParticipants = 0)
    {
        // Base case: if we've filled the left tug, check if sums are equal
        if (leftTugParticipants >= leftTug.Length)
        {
            var rightTug = GetRightTug(set, included);
            return rightTug.Sum() == leftTug.Sum();
        }

        // Try each unused number in the left tug
        var candidateIndex = FindNextCandidate(set, included, 0);
        while (candidateIndex != -1)
        {
            // Include current number in left tug
            leftTug[leftTugParticipants] = set[candidateIndex];
            included[candidateIndex] = true;

            // Recursively try to complete the solution
            if (TryFindTug(set, included, leftTug, leftTugParticipants + 1))
            {
                return true;
            }

            // Backtrack
            included[candidateIndex] = false;
            candidateIndex = FindNextCandidate(set, included, candidateIndex + 1);
        }

        return false;
    }

    private static int[] GetRightTug(IReadOnlyList<int> set, IReadOnlyList<bool> included)
    {
        var rightSize = set.Count - included.Count(x => x);
        var result = new int[rightSize];
        var resultIndex = 0;

        for (var i = 0; i < set.Count; i++)
        {
            if (!included[i])
            {
                result[resultIndex++] = set[i];
            }
        }

        return result;
    }

    private static int FindNextCandidate(IReadOnlyCollection<int> set, IReadOnlyList<bool> included, int startFrom)
    {
        for (var i = startFrom; i < set.Count; i++)
        {
            if (!included[i])
            {
                return i;
            }
        }
        return -1;
    }
}