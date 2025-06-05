using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.DataStructures.SuffixArray;

public class NaiveSuffixArray
{
    private readonly string input;
    private readonly List<int> suffixes;

    public NaiveSuffixArray(string input)
    {
        suffixes = string.IsNullOrEmpty(input) ? Array.Empty<int>().ToList() : BuildSuffixArray(input);
        this.input = input;
    }

    public IReadOnlyCollection<int> Suffixes => suffixes.ToList().AsReadOnly();

    private static List<int> BuildSuffixArray(string input)
    {
        var suffixArray = new NaiveSuffixArrayNode[input.Length];

        for (var i = 0; i < suffixArray.Length; i++)
            suffixArray[i] = new NaiveSuffixArrayNode { Suffix = input.Substring(i), Index = i };

        suffixArray = suffixArray.OrderBy(arg => arg.Suffix).ToArray();

        return suffixArray.Select(arg => arg.Index).ToList();
    }

    public bool Contains(string pattern)
    {
        if (string.IsNullOrEmpty(pattern)) return true;

        var start = 0;
        var end = suffixes.Count - 1;

        while (start < end)
        {
            var mid = start + (end - start) / 2;
            var substring = input.Substring(mid, Math.Min(pattern.Length, input.Length - mid));

            var comparisonResult = string.Compare(substring, pattern, StringComparison.InvariantCulture);

            if (comparisonResult == 0) return true;

            if (comparisonResult > 0)
                start = mid + 1;
            else
                end = mid - 1;
        }

        return false;
    }
}