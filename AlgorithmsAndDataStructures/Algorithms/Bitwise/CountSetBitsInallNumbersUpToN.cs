namespace AlgorithmsAndDataStructures.Algorithms.Bitwise;

public class CountSetBitsInAllNumbersUpToN
{
#pragma warning disable CA1822 // Mark members as static
    public int Count(int n)
#pragma warning restore CA1822 // Mark members as static
    {
        var result = 0;

        for (var i = 1; i < n; i++) result += CountBits(i);

        return result;
    }

    private static int CountBits(int number)
    {
        if (number <= 0) return 0;

        return (number % 2 == 0 ? 0 : 1) + CountBits(number / 2);
    }
}