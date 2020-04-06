namespace AlgorithmsAndDataStructures.Algorithms.DynamicProgramming
{
    public class FibonacciNumber
    {
        public int GetNumber(int number)
        {
            if (number == 0)
            {
                return number;
            }

            var dp = new int[number + 1];
            dp[0] = 0;
            dp[1] = 1;

            for (int i = 2; i <= number; i++)
            {
                dp[i] = dp[i - 2] + dp[i - 1]; 
            }

            return dp[number];
        }
    }
}
