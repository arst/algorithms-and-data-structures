using System;

namespace AlgorithmsAndDataStructures.Algorithms.DynamicProgramming;

public class UnboundedKnapsack
{
#pragma warning disable CA1822 // Mark members as static
    public int GetMaxGain(int[] weights, int[] values, int knapsackSize)
#pragma warning restore CA1822 // Mark members as static
    {
        if (weights is null || values is null) return default;

        var dp = new int[knapsackSize + 1];

        for (var i = 0; i < dp.Length; i++)
        for (var j = 0; j < weights.Length; j++)
            if (weights[j] <= i)
                dp[i] = Math.Max(dp[i], dp[i - weights[j]] + values[j]);

        return dp[knapsackSize];
    }
}