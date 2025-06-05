using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Strings.Search;

public class BooyerMooreCombinedHeuristic : IStringPatternSearchAlgorithm
{
    public int Search(string input, string pattern)
    {
        if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(pattern)) return -1;

        var badCharacterHeuristicTable = BuildBadCharacterHeuristicTable(pattern);

        var goodSuffixHeuristic = BuildGodSuffixHeuristic(pattern);
        PostProcessGodSuffixHeuristic(pattern, goodSuffixHeuristic);

        var patternIndex = pattern.Length - 1;
        var inputIndex = pattern.Length - 1;

        while (inputIndex < input.Length)
        {
            var isMatch = input[inputIndex] == pattern[patternIndex];
            if (isMatch)
            {
                inputIndex--;
                patternIndex--;
            }

            if (patternIndex < 0) return inputIndex + 1;

            if (inputIndex > 0 && !isMatch)
            {
                if (patternIndex == pattern.Length - 1)
                {
                    inputIndex++;
                }
                else
                {
                    var mismatchedCharacter = input[inputIndex];
                    patternIndex = pattern.Length - 1;
                    var goodSuffixHeuristicShift = goodSuffixHeuristic.shifts[patternIndex + 1];
                    var badSuffixHeuristicShift = badCharacterHeuristicTable.ContainsKey(mismatchedCharacter)
                        ? badCharacterHeuristicTable[mismatchedCharacter]
                        : pattern.Length;

                    inputIndex += Math.Max(goodSuffixHeuristicShift, badSuffixHeuristicShift);
                }
            }
        }

        return -1;
    }

    private static Dictionary<char, int> BuildBadCharacterHeuristicTable(string pattern)
    {
        var result = new Dictionary<char, int>();

        for (var i = 0; i < pattern.Length - 1; i++) result[pattern[i]] = pattern.Length - i - 1;

        return result;
    }

    private static void PostProcessGodSuffixHeuristic(string pattern, (int[] borders, int[] shifts) goodSuffixHeuristic)
    {
        int i;
        var (borders, shifts) = goodSuffixHeuristic;
        var j = borders[0];
        for (i = 0; i <= pattern.Length; i++)
        {
            if (shifts[i] == 0)
                shifts[i] = j;

            if (i == j)
                j = borders[j];
        }
    }

    private static (int[] borders, int[] shifts) BuildGodSuffixHeuristic(string pattern)
    {
        var borders = new int[pattern.Length + 1];
        var shifts = new int[pattern.Length + 1];

        var suffixStart = pattern.Length;
        var borderStarts = pattern.Length + 1;
        borders[suffixStart] = borderStarts;

        while (suffixStart > 0)
        {
            while (borderStarts <= pattern.Length && pattern[suffixStart - 1] != pattern[borderStarts - 1])
            {
                if (shifts[borderStarts] == 0) shifts[borderStarts] = borderStarts - 1;

                borderStarts = borders[borderStarts];
            }

            suffixStart--;
            borderStarts--;
            borders[suffixStart] = borderStarts;
        }

        return (borders, shifts);
    }
}