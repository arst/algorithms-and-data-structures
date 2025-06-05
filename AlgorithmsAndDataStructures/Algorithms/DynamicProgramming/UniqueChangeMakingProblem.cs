namespace AlgorithmsAndDataStructures.Algorithms.DynamicProgramming;

public class UniqueChangeMakingProblem
{
#pragma warning disable CA1822 // Mark members as static
    public int GetTotalNumberOfPossibleExchanges(int[] coins, int value)
#pragma warning restore CA1822 // Mark members as static
    {
        if (coins is null) return default;

        var dp = new int[coins.Length + 1][];

        for (var i = 0; i < dp.Length; i++)
        {
            dp[i] = new int[value + 1];
            dp[i][0] = 1;
        }

        for (var currentCoinsAvailable = 1; currentCoinsAvailable < dp.Length; currentCoinsAvailable++)
        for (var currentAmount = 1; currentAmount < dp[currentCoinsAvailable].Length; currentAmount++)
            dp[currentCoinsAvailable][currentAmount] = dp[currentCoinsAvailable - 1][currentAmount]
                                                       + (currentAmount - coins[currentCoinsAvailable - 1] >= 0
                                                           ? dp[currentCoinsAvailable][
                                                               currentAmount - coins[currentCoinsAvailable - 1]]
                                                           : 0);

        return dp[coins.Length][value];
    }
}