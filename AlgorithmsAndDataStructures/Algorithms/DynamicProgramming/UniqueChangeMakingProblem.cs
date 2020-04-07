namespace AlgorithmsAndDataStructures.Algorithms.DynamicProgramming
{
    public class UniqueChangeMakingProblem
    {
        public int GetTotalNumberOfPossibleExchanges(int[] coins, int value)
        {
            var dp = new int[coins.Length + 1][];

            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[value + 1];
                dp[i][0] = 1;
            }

            for (int currenvCoinsAvailable = 1; currenvCoinsAvailable < dp.Length; currenvCoinsAvailable++)
            {
                for (int currentAmount = 1; currentAmount < dp[currenvCoinsAvailable].Length; currentAmount++)
                {
                    dp[currenvCoinsAvailable][currentAmount] = dp[currenvCoinsAvailable - 1][currentAmount]
                        + (currentAmount - coins[currenvCoinsAvailable - 1] >= 0 ? dp[currenvCoinsAvailable][currentAmount - coins[currenvCoinsAvailable - 1]] : 0);
                }
            }

            return dp[coins.Length][value];
        }
    }
}
