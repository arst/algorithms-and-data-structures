using System;

namespace AlgorithmsAndDataStructures.Algorithms.String.Sorting
{
    public class MSD
    {
        public string[] Sort(string[] input)
        {
            var length = input.Length;
            var auxilary = new string[input.Length];
            SortInternal(input, auxilary, 0, length - 1, 0);

            return input;
        }

        private void SortInternal(string[] input, string[] auxilary, int start, int end, int currentCharacter)
        {
            if (start >= end)
            {
                return;
            }

            const int alphabetSize = 256;
            // We need 2 additional places here because 0 would correspond to the end of the string aka -1 index
            // So counters should shift one additional place to make place for -1 character
            var counter = new int[256 + 2];

            for (int i = start; i <= end; i++)
            {
                // In LSD we shift them by one to build indexes from counters
                // Here we do the same but we need to shift them by 2 to makr place for -1 character
                counter[CharAt(input[i], currentCharacter) + 2]++;
            }

            for (int i = 0; i < counter.Length - 1; i++)
            {
                counter[i + 1] += counter[i];
            }

            for (int i = start; i <= end; i++)
            {
                auxilary[counter[CharAt(input[i], currentCharacter) + 1]++] = input[i];
            }

            for (int i = start; i <= end; i++)
            {
                // To convert auxilty indexes we need to substract start position from auxilary index
                // Since when we filled auxilary we started at start position
                input[i] = auxilary[i - start];
            }

            for (int i = 0; i < alphabetSize; i++)
            {
                // Sort each subarray divided by first character in current substring
                SortInternal(input, auxilary, start + counter[i], start + counter[i+1] - 1, currentCharacter + 1);
            }
        }

        private int CharAt(string input, int index)
        {
            if (index >= input.Length)
            {
                return -1;
            }

            return input[index];
        }
    }
}
