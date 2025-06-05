﻿namespace AlgorithmsAndDataStructures.Algorithms.Strings.Search;

public class RecursivePatternSearch : IStringPatternSearchAlgorithm
{
    public int Search(string input, string pattern)
    {
        if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(pattern)) return -1;

        return SearchInternal(input, 0, pattern, 0);
    }

    private static int SearchInternal(string input, int inputPosition, string pattern, int patternPosition)
    {
        if (input.Length - inputPosition < pattern.Length - patternPosition) return -1;

        if (input[inputPosition] == pattern[patternPosition])
        {
            if (patternPosition == pattern.Length - 1) return inputPosition - pattern.Length + 1;

            return SearchInternal(input, inputPosition + 1, pattern, patternPosition + 1);
        }

        return SearchInternal(input, patternPosition != 0 ? inputPosition : inputPosition + 1, pattern, 0);
    }
}