﻿using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Strings.Search;

public class BoyerMooreBadCharacterHeuristic : IStringPatternSearchAlgorithm
{
    public int Search(string input, string pattern)
    {
        if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(pattern)) return -1;

        var badCharacterHeuristicTable = BuildBadCharacterHeuristicTable(pattern);

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
                    inputIndex += badCharacterHeuristicTable.ContainsKey(mismatchedCharacter)
                        ? badCharacterHeuristicTable[mismatchedCharacter]
                        : pattern.Length;
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
}