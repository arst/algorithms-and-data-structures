using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.DynamicProgramming
{
    public class DigitDynamicProgtamming
    {
        public int GetCount(int lowerNumber, int upperNumber, int sum)
        {
            var fromZeroToUpper = CalculateInternal(0, sum, true, GetNumberAsVector(upperNumber), sum, GetDpTable(sum));
            var fromZeroToLower = (lowerNumber > 1 ? CalculateInternal(0, sum, true, GetNumberAsVector(lowerNumber - 1), sum, GetDpTable(sum)) : 0);

            return fromZeroToUpper - fromZeroToLower;
        }

        private int CalculateInternal(int currentPosition, int currentSum, bool isOnTheEdge, int[] upperNumberAsVector, int targetSum, int[][][] dp)
        {
            if (currentSum  == 0)
            {
                return 1;
            }

            if (currentPosition > upperNumberAsVector.Length - 1)
            {
                return 0;
            }

            if (dp[currentPosition][currentSum][isOnTheEdge ? 1 : 0] != -1)
            {
                return dp[currentPosition][currentSum][isOnTheEdge ? 1 : 0];
            }

            int limit;

            if (isOnTheEdge)
            {
                limit = upperNumberAsVector[currentPosition];
            }
            else
            {
                limit = 9;
            }

            var counter = 0;

            for (int i = 0; i <= limit; i++)
            {
                var isOnTheEdgeCurrent = isOnTheEdge;

                if (isOnTheEdge && i < limit)
                {
                    isOnTheEdgeCurrent = false;
                }

                if (currentSum - i < 0)
                    break;

                counter += CalculateInternal(currentPosition + 1, currentSum - i, isOnTheEdgeCurrent, upperNumberAsVector, targetSum, dp);
            }

            dp[currentPosition][currentSum][isOnTheEdge ? 1 : 0] = counter;

            return dp[currentPosition][currentSum][isOnTheEdge ? 1 : 0];
        }

        private int[] GetNumberAsVector(int input)
        {
            var number = input;
            var temp = new List<int>();
            while (number > 0)
            {
                temp.Add(number % 10);
                number /= 10;
            }

            temp.Reverse();

            return temp.ToArray();
        }

        private static int[][][] GetDpTable(int sum)
        {
            var dp = new int[9][][];

            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[sum + 1][];

                for (int j = 0; j < dp[i].Length; j++)
                {
                    dp[i][j] = new int[2];

                    for (int k = 0; k < dp[i][j].Length; k++)
                    {
                        dp[i][j][k] = -1;
                    }
                }
            }

            return dp;
        }
    }
}
