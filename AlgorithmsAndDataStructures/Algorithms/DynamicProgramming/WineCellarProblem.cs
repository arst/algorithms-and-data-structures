using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.DynamicProgramming;

/*
 Imagine you have a collection of N wines placed next to each other on a shelf.
 For simplicity, let's number the wines from left to right as they are standing on the shelf with integers from 1 to N, respectively.
 The price of the ith wine is pi. (prices of different wines can be different).
 Because the wines get better every year, supposing today is the year 1, on year y the price of the ith wine will be y*pi, i.e. y-times the value that current year.
 You want to sell all the wines you have, but you want to sell exactly one wine per year, starting on this year.
 One more constraint - on each year you are allowed to sell only either the leftmost or the rightmost wine on the shelf and you are not allowed to reorder the wines on the shelf (i.e. they must stay in the same order as they are in the beginning).
 You want to find out, what is the maximum profit you can get, if you sell the wines in optimal order?"*/
public class WineCellarProblem
{
#pragma warning disable CA1822 // Mark members as static
    public int GetMaxProfit(int[] prices)
#pragma warning restore CA1822 // Mark members as static
    {
        if (prices is null) return default;

        var dp = new int[prices.Length][];

        for (var i = 0; i < prices.Length; i++) dp[i] = new int[prices.Length];

        return GetOrderRecursive(prices, 0, prices.Length - 1, dp);
    }

    private static int GetOrderRecursive(IReadOnlyList<int> prices, int start, int end, IReadOnlyList<int[]> dp)
    {
        if (start > end) return 0;

        if (dp[start][end] != 0) return dp[start][end];

        // Each year we allowed to sell only one bottle, so we can derive current year from difference between all bottles and sold bottles
        var year = prices.Count - (end - start);

        dp[start][end] = Math.Max(
            GetOrderRecursive(prices, start + 1, end, dp) + year * prices[start],
            GetOrderRecursive(prices, start, end - 1, dp) + year * prices[end]);

        return dp[start][end];
    }
}