using System;

namespace AlgorithmsAndDataStructures.Algorithms.DynamicProgramming
{
    public class UnboundedKnapsack
    {
        public int GetMaxGain(int[] weights, int[] values, int knapsackSize)
        {
            var dp = new int[knapsackSize + 1];

            for (int i = 0; i < dp.Length; i++)
            {
                for (int j = 0; j < weights.Length; j++)
                {
                    if (weights[j] <= i)
                    {
                        dp[i] = Math.Max(dp[i], dp[i - weights[j]] + values[j]);
                    }
                }
            }

            return dp[knapsackSize];
        }
    }
}
