using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Strings.Sorting;

public class Msd
{
#pragma warning disable CA1822 // Mark members as static
    public string[] Sort(string[] input)
#pragma warning restore CA1822 // Mark members as static
    {
        if (input is null) return default;

        var length = input.Length;
        var auxiliary = new string[input.Length];
        SortInternal(input, auxiliary, 0, length - 1, 0);

        return input;
    }

    private static void SortInternal(IList<string> input, IList<string> auxiliary, int start, int end,
        int currentCharacter)
    {
        if (start >= end) return;

        const int alphabetSize = 256;
        // We need 2 additional places here because 0 would correspond to the end of the string aka -1 index
        // So counters should shift one additional place to make place for -1 character
        var counter = new int[256 + 2];

        for (var i = start; i <= end; i++)
            // In LSD we shift them by one to build indexes from counters
            // Here we do the same but we need to shift them by 2 to makr place for -1 character
            counter[CharAt(input[i], currentCharacter) + 2]++;

        for (var i = 0; i < counter.Length - 1; i++) counter[i + 1] += counter[i];

        for (var i = start; i <= end; i++) auxiliary[counter[CharAt(input[i], currentCharacter) + 1]++] = input[i];

        for (var i = start; i <= end; i++)
            // To convert auxiliary indexes we need to subtract start position from auxiliary index
            // Since when we filled auxiliary we started at start position
            input[i] = auxiliary[i - start];

        for (var i = 0; i < alphabetSize; i++)
            // Sort each sub-array divided by first character in current substring
            SortInternal(input, auxiliary, start + counter[i], start + counter[i + 1] - 1, currentCharacter + 1);
    }

    private static int CharAt(string input, int index)
    {
        if (index >= input.Length) return -1;

        return input[index];
    }
}