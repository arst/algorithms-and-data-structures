using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorithmsAndDataStructures.DataStructures.SuffixArray
{
    public class EfficientSuffixArray
    {
        private readonly int[] suffixes;
        private readonly string input;

        public IReadOnlyCollection<int> Suffixes => suffixes.ToList().AsReadOnly();

        public EfficientSuffixArray(string input)
        {
            suffixes = string.IsNullOrEmpty(input) ? Array.Empty<int>() : Build(input);
            this.input = input;
        }

        private static int[] Build(string input)
        {
            var ordering = new int[input.Length];
            var tuples = new EfficientSuffixArrayNode[input.Length];

            for (var i = 0; i < input.Length - 1; i++)
            {
                tuples[i] = new EfficientSuffixArrayNode(input)
                {
                    Index = i,
                    Rank = input[i],
                    NextRank = input[i + 1],
                };
            }

            tuples[input.Length - 1] = new EfficientSuffixArrayNode(input)
            {
                Index = input.Length - 1,
                Rank = input[input.Length - 1],
                NextRank = -1,
            };

            Array.Sort(tuples); // can be raplced with Radix sort to make it more performant

            for (var prefixLength = 4; input.Length * 2 > prefixLength; prefixLength = prefixLength * 2)
            {
                var rank = 0;
                var previousSuffixRank = tuples[0].Rank;
                tuples[0].Rank = 0;

                for (var j = 1; j < input.Length; j++)
                {
                    if (tuples[j].Rank == previousSuffixRank && tuples[j].NextRank == tuples[j - 1].NextRank)
                    {
                        previousSuffixRank = tuples[j].Rank;
                        tuples[j].Rank = rank;
                    }
                    else
                    {
                        previousSuffixRank = tuples[j].Rank;
                        tuples[j].Rank = ++rank;
                    }

                    ordering[tuples[j].Index] = j;
                }

                for (var i = 0; i < input.Length; i++)
                {
                    var next = tuples[i].Index + prefixLength / 2;
                    tuples[i].NextRank = next < input.Length ? tuples[ordering[next]].Rank : -1;
                }

                Array.Sort(tuples); // can be replaced with Radix sort to make it more pre-formant
            }

            return tuples.Select(arg => arg.Index).ToArray(); 
            
        }

        public bool Contains(string pattern)
        {
            if (string.IsNullOrEmpty(pattern))
            {
                return true;
            }

            var start = 0;
            var end = suffixes.Length - 1;

            while (start < end)
            {
                var mid = start + (end - start) / 2;
                var substring = input.Substring(mid, Math.Min(pattern.Length, input.Length - mid));

                var comparisonResult = string.Compare(substring, pattern, StringComparison.InvariantCulture);

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
