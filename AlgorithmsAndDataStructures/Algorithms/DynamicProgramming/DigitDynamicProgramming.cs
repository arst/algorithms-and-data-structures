using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.DynamicProgramming;

public class DigitDynamicProgramming
{
#pragma warning disable CA1822 // Mark members as static
    public int GetCount(int lowerNumber, int upperNumber, int sum)
#pragma warning restore CA1822 // Mark members as static
    {
        var fromZeroToUpper = CalculateInternal(0, sum, true, GetNumberAsVector(upperNumber), GetDpTable(sum));
        var fromZeroToLower = lowerNumber > 1
            ? CalculateInternal(0, sum, true, GetNumberAsVector(lowerNumber - 1), GetDpTable(sum))
            : 0;

        return fromZeroToUpper - fromZeroToLower;
    }

    private static int CalculateInternal(int currentPosition, int currentSum, bool isOnTheEdge,
        IReadOnlyList<int> upperNumberAsVector, IReadOnlyList<int[][]> dp)
    {
        if (currentSum == 0) return 1;

        if (currentPosition > upperNumberAsVector.Count - 1) return 0;

        if (dp[currentPosition][currentSum][isOnTheEdge ? 1 : 0] != -1)
            return dp[currentPosition][currentSum][isOnTheEdge ? 1 : 0];

        var limit = isOnTheEdge ? upperNumberAsVector[currentPosition] : 9;

        var counter = 0;

        for (var i = 0; i <= limit; i++)
        {
            var isOnTheEdgeCurrent = isOnTheEdge;

            if (isOnTheEdge && i < limit) isOnTheEdgeCurrent = false;

            if (currentSum - i < 0)
                break;

            counter += CalculateInternal(currentPosition + 1, currentSum - i, isOnTheEdgeCurrent, upperNumberAsVector,
                dp);
        }

        dp[currentPosition][currentSum][isOnTheEdge ? 1 : 0] = counter;

        return dp[currentPosition][currentSum][isOnTheEdge ? 1 : 0];
    }

    private static int[] GetNumberAsVector(int input)
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
        // We have 9 digits.
        var dp = new int[9][][];

        for (var i = 0; i < dp.Length; i++)
        {
            // We can get value more then target sum. +1 os for 0.
            dp[i] = new int[sum + 1][];

            for (var j = 0; j < dp[i].Length; j++)
            {
                //We have binary value for being on the edge, we either on it or no.
                dp[i][j] = new int[2];

                for (var k = 0; k < dp[i][j].Length; k++) dp[i][j][k] = -1;
            }
        }

        return dp;
    }
}