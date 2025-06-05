using System;
using AlgorithmsAndDataStructures.Algorithms.Utils;

namespace AlgorithmsAndDataStructures.Algorithms.DynamicProgramming;

public class ZeroOneKnapsack
{
    // NOTE: Since it's a 0/1 you can get each item only once.
#pragma warning disable CA1822 // Mark members as static
    public int GetMaxGain(int[] weights, int[] values, int knapsackSize)
#pragma warning restore CA1822 // Mark members as static
    {
        if (weights is null || values is null || weights.Length == 0 || values.Length == 0) return 0;

        var dp = ArrayUtils.InitializeMultiDimensionalArray<int>(weights.Length, knapsackSize + 1);

        for (var i = 1; i < dp[0].Length; i++)
            // Initialize first row, we have only one object available, so it it fits we take it.
            dp[0][i] = weights[0] <= i ? values[0] : 0;

        // Object 0 is already considered above so we start with 0,1 object available.
        for (var i = 1; i < dp.Length; i++)
            // nothing could fir into weight 0.
        for (var j = 1; j < dp[i].Length; j++)
            // Object i could fit, try to take it.
            dp[i][j] = weights[i] <= j
                ? Math.Max(values[i] + dp[i - 1][j - weights[i]], dp[i - 1][j])
                : dp[i - 1][j];

        return dp[weights.Length - 1][knapsackSize];
    }
}