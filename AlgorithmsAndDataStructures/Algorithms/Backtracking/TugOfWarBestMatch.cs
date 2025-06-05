using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.Backtracking;

/// <summary>
/// Solves the Tug of War problem by finding two subsets with the minimum possible difference in sums.
/// Unlike the basic TugOfWar, this version finds the best possible split even when equal sums are not possible.
/// </summary>
public class TugOfWarBestMatch
{
    /// <summary>
    /// Finds two subsets with minimal difference in sums from the given set.
    /// </summary>
    /// <param name="set">Input array of numbers</param>
    /// <returns>Two arrays representing left and right subsets with minimal sum difference</returns>
    public (int[] left, int[] right) GetTug(int[] set)
    {
        if (set == null || set.Length == 0)
        {
            return (Array.Empty<int>(), Array.Empty<int>());
        }

        // For odd-length sets, left side gets (n-1)/2 elements, right side gets (n+1)/2
        var leftTugLength = set.Length % 2 == 1 ? (set.Length - 1) / 2 : set.Length / 2;
        var currentState = new bool[set.Length];
        var bestSolution = new bool[set.Length];
        
        FindBestSplit(set, currentState, 0, int.MaxValue, bestSolution, leftTugLength);
        
        return (ExtractSubset(set, bestSolution, true),
               ExtractSubset(set, bestSolution, false));
    }

    private static int FindBestSplit(
        IReadOnlyList<int> set,
        bool[] currentState,
        int leftTugSize,
        int bestDifference,
        bool[] bestSolution,
        int targetLeftSize)
    {
        if (leftTugSize >= targetLeftSize)
        {
            var leftSum = GetSubsetSum(set, currentState, true);
            var rightSum = GetSubsetSum(set, currentState, false);
            var difference = Math.Abs(rightSum - leftSum);

            if (difference < bestDifference)
            {
                Array.Copy(currentState, bestSolution, currentState.Length);
                return difference;
            }

            return bestDifference;
        }

        var candidateIndex = FindNextCandidate(set, currentState, 0);
        while (candidateIndex != -1 && leftTugSize < targetLeftSize)
        {
            currentState[candidateIndex] = true;
            bestDifference = FindBestSplit(
                set, currentState, leftTugSize + 1, bestDifference, bestSolution, targetLeftSize);

            currentState[candidateIndex] = false;
            candidateIndex = FindNextCandidate(set, currentState, candidateIndex + 1);
        }

        return bestDifference;
    }

    private static int GetSubsetSum(IReadOnlyList<int> set, IReadOnlyList<bool> included, bool wantIncluded)
    {
        var sum = 0;
        for (var i = 0; i < set.Count; i++)
        {
            if (included[i] == wantIncluded)
            {
                sum += set[i];
            }
        }
        return sum;
    }

    private static int[] ExtractSubset(IReadOnlyList<int> set, IReadOnlyList<bool> included, bool wantIncluded)
    {
        var size = included.Count(x => x == wantIncluded);
        var result = new int[size];
        var index = 0;

        for (var i = 0; i < set.Count; i++)
        {
            if (included[i] == wantIncluded)
            {
                result[index++] = set[i];
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