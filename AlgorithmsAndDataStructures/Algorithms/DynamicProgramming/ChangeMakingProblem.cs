using System;

namespace AlgorithmsAndDataStructures.Algorithms.DynamicProgramming
{
    public class ChangeMakingProblem
    {
#pragma warning disable CA1822 // Mark members as static
        public int GetMinChange(int[] coins, int value)
#pragma warning restore CA1822 // Mark members as static
        {
            if (coins is null || coins.Length == 0)
            {
                return 0;
            }

            var dp = new int[value + 1];

            for (var i = 1; i < dp.Length; i++)
            {
                dp[i] = int.MaxValue;

                foreach (var coin in coins)
                {
                    if (coin <= i)
                    {
                        dp[i] = Math.Min(dp[i], dp[i - coin] + 1);
                    }
                }
            }

            return dp[value];
        }
    }
}
