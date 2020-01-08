using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.DataStructures.SuffixArray
{
    public class NaiveSuffixArray
    {
        private List<int> suffixes;
        private readonly string input;

        public IReadOnlyCollection<int> Suffixes => suffixes.ToList().AsReadOnly();

        public NaiveSuffixArray(string input)
        {
            suffixes = BuildSuffixArray(input);
            this.input = input;
        }

        private List<int> BuildSuffixArray(string input)
        {
            var suffixArray = new NaiveSuffixArrayNode[input.Length];

            for (int i = 0; i < suffixArray.Length; i++)
            {
                suffixArray[i] = new NaiveSuffixArrayNode();
                suffixArray[i].Suffix = input.Substring(i);
                suffixArray[i].Index = i;
            }

            suffixArray = suffixArray.OrderBy(arg => arg.Suffix).ToArray();

            return suffixArray.Select(arg => arg.Index).ToList();
        }

        public bool Contains(string pattern)
        {
            var start = 0;
            var end = suffixes.Count - 1;

            while (start < end)
            {
                var mid = start + (end - start) / 2;
                var substring = input.Substring(mid, Math.Min(pattern.Length, input.Length - mid));

                var comparisonResult = substring.CompareTo(pattern);

                if (comparisonResult == 0)
                {
                    return true;
                }

                if (comparisonResult > 0)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }

            return false;
        }
    }
}
