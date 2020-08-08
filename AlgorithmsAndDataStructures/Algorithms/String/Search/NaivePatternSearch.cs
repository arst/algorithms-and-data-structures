using System;

namespace AlgorithmsAndDataStructures.Algorithms.String.Search
{
    public class NaivePatternSearch : IStringPatternSearchAlgorithm
    {
        public int Search(string input, string pattern)
        {
            if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(pattern))
            {
                throw new ArgumentNullException($"{nameof(input)} and {nameof(pattern)} can't be null.");
            }

            const int negativeResult = -1;

            if (pattern.Length > input.Length)
            {
                return negativeResult;
            }

            for (var i = 0; i <= input.Length - pattern.Length; i++)
            {
                if (input[i] == pattern[0])
                {
                    var originalPosition = i + 1;
                    var isMatch = true;

                    for (var j = 1; j < pattern.Length; j++)
                    {
                        if (input[originalPosition] != pattern[j])
                        {
                            isMatch = false;
                            break;
                        }
                        originalPosition++;
                    }

                    if (isMatch)
                    {
                        return i;
                    }
                }
            }

            return negativeResult;
        }
    }
}
