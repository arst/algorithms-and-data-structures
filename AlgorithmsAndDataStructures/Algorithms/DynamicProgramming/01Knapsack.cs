using System;

namespace AlgorithmsAndDataStructures.Algorithms.DynamicProgramming
{
    public class _01Knapsack
    {
        public int GetMaxGain(int[] weights, int[] values, int knapsackSize)
        {
            var dp = new int[weights.Length][];

            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[knapsackSize + 1];
            }

            for (int i = 1; i < dp[0].Length; i++)
            {
                dp[0][i] = weights[0] <= i ? values[0] : 0;
            }

            for (int i = 1; i < dp.Length; i++)
            {
                for (int j = 1; j < dp[i].Length; j++)
                {
                    dp[i][j] = weights[i] <= j
                        ? Math.Max(values[i] + dp[i - 1][j - weights[i]], dp[i - 1][j])
                        : dp[i - 1][j];
                }
            }

            return dp[weights.Length - 1][knapsackSize];
        }
    }
}
