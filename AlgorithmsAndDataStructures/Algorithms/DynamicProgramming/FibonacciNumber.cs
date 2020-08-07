namespace AlgorithmsAndDataStructures.Algorithms.DynamicProgramming
{
    public class FibonacciNumber
    {
#pragma warning disable CA1822 // Mark members as static
        public int GetNumber(int number)
#pragma warning restore CA1822 // Mark members as static
        {
            if (number == 0)
            {
                return number;
            }

            var dp = new int[number + 1];
            dp[0] = 0;
            dp[1] = 1;

            for (var i = 2; i <= number; i++)
            {
                dp[i] = dp[i - 2] + dp[i - 1]; 
            }

            return dp[number];
        }
    }
}
