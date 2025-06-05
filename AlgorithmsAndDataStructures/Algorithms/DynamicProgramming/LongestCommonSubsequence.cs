using System;

namespace AlgorithmsAndDataStructures.Algorithms.DynamicProgramming;

public class LongestCommonSubsequence
{
#pragma warning disable CA1822 // Mark members as static
    public int GetLongestSunsequence(string left, string right)
#pragma warning restore CA1822 // Mark members as static
    {
        if (string.IsNullOrEmpty(left) || string.IsNullOrEmpty(right)) return default;

        var dp = new int[left.Length + 1][];

        for (var i = 0; i < dp.Length; i++) dp[i] = new int[right.Length + 1];

        for (var i = 1; i <= left.Length; i++)
        for (var j = 1; j <= right.Length; j++)
            dp[i][j] = left[i - 1] == right[j - 1]
                ? 1 + dp[i - 1][j - 1] // characters matched so we can add 1 to the result of the previous sub problem
                : Math.Max(
                    dp[i][j - 1] /*remove one character from the  left string*/,
                    dp[i - 1][j] /*remove one character from the right string*/);

        return dp[left.Length][right.Length];
    }
}