using System;

namespace AlgorithmsAndDataStructures.Algorithms.StringAlgorithms.Search
{
    public class KnuthMorrisPratt : IStringPatternSearchAlgorithm
    {
        public int Search(string input, string pattern)
        {
            if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(pattern))
            {
                throw new ArgumentNullException($"{nameof(input)} and {nameof(pattern)} can't be null.");
            }

            var aux = ComputeAuxArray(pattern);
            var patternIndex = 0;
            var inputIndex = 0;

            while (inputIndex < input.Length)
            {
                // It's a match, proceed to the next pair
                if (pattern[patternIndex] == input[inputIndex])
                {
                    patternIndex++;
                    inputIndex++;
                }
                // All pattern characters matched, return the result
                if (patternIndex == pattern.Length)
                {
                    return inputIndex - patternIndex;
                }
                // No match and some characters in input left undiscovered

                if (inputIndex < input.Length && pattern[patternIndex] != input[inputIndex])
                {
                    //Pattern at non-starting position, try to match some prefix
                    if (patternIndex != 0)
                    {
                        patternIndex = aux[patternIndex - 1];
                    }
                    // Pattern[0] mismatched with current character, there is nothing to do, just proceed to the next character
                    else
                    {
                        inputIndex++;
                    }
                }
            }

            return -1;
        }

        private static int[] ComputeAuxArray(string pattern)
        {
            var result = new int[pattern.Length];

            var prefixLength = 0;
            result[prefixLength] = 0;
            var currentCharacter = 1;

            while (currentCharacter < result.Length)
            {
                // If prefix at currentposition equal to currently inspected suffix character then procesd with growing prefix
                if (pattern[prefixLength] == pattern[currentCharacter])
                {
                    prefixLength++;
                    result[currentCharacter] = prefixLength;
                    currentCharacter++;
                }
                else
                {
                    // Prefix and suffix character aren't matche, try smaller prefix
                    if (prefixLength != 0)
                    {
                        prefixLength = result[prefixLength - 1];
                    }
                    else
                    {
                        //No prefixes left to imnspect, give up and proceed to the next character
                        result[currentCharacter] = 0;
                        currentCharacter++;
                    }
                }
            }

            return result;
        }
    }
}
