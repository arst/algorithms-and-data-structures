namespace AlgorithmsAndDataStructures.Algorithms.DynamicProgramming
{
    public class RepresentNasSumOf134
    {
#pragma warning disable CA1822 // Mark members as static
        public int Get(int n)
#pragma warning restore CA1822 // Mark members as static
        {
            if (n == 0)
                return n;

            if (n < 3)
                return 1;

            if (n == 3)
                return 2;

            var dp = new int[n + 1];

            dp[0] = 0;
            dp[1] = 1;
            dp[2] = 1;
            dp[3] = 2;
            dp[4] = 4;

            for (var i = 5; i <= n; i++)
            {
                dp[n] = dp[n - 1] + dp[n - 3] + dp[n - 4];
            }

            return dp[n];
        }
    }
}
