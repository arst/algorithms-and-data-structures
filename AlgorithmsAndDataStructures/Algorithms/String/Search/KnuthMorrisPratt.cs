using System;

namespace AlgorithmsAndDataStructures.Algorithms.String.Search
{
    public class KnuthMorrisPratt : IStringPatternSearchAlgorithm
    {
        public int Search(string input, string pattern)
        {
            var aux = ComputeAuxArray(pattern);
            var patternIndex = 0;
            var inputIndex = 0;

            while (inputIndex < input.Length)
            {
                if (pattern[patternIndex] == input[inputIndex])
                {
                    inputIndex++;
                    patternIndex++;
                }

                if (patternIndex == pattern.Length)
                {
                    return inputIndex - patternIndex;
                }
                else if (inputIndex < input.Length && pattern[patternIndex] != input[inputIndex])
                {
                    if (patternIndex != 0)
                    {
                        patternIndex = aux[patternIndex - 1];
                    }
                    else
                    {
                        inputIndex++;
                    }
                }
            }

            return -1;
        }

        private int[] ComputeAuxArray(string pattern)
        {
            var result = new int[pattern.Length];
            var currentCharacter = 1;
            var suffixLength = 0;
            result[suffixLength] = 0;

            while (currentCharacter < result.Length)
            {
                if (pattern[currentCharacter] == pattern[suffixLength])
                {
                    suffixLength++;
                    result[currentCharacter] = suffixLength;
                    currentCharacter++;
                }
                else
                {
                    if (suffixLength != 0)
                    {
                        suffixLength = result[suffixLength - 1];
                    }
                    else
                    {
                        result[currentCharacter] = 0;
                        currentCharacter++;
                    }
                }
            }

            return result;
        }
    }
}
