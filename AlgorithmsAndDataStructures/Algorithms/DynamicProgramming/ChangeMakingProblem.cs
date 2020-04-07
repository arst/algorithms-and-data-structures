using System;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.DynamicProgramming
{
    public class ChangeMakingProblem
    {
        public int GetMinChange(int[] coins, int value)
        {
            var dp = new int[value + 1];

            for (int i = 1; i < dp.Length; i++)
            {
                dp[i] = int.MaxValue;

                for (int j = 0; j < coins.Length; j++)
                {
                    if (coins[j] <= i)
                    {
                        dp[i] = Math.Min(dp[i], dp[i - coins[j]] + 1);
                    }
                }
            }

            return dp[value];
        }
    }
}
