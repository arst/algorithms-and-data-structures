namespace AlgorithmsAndDataStructures.Algorithms.Bitwise;

public class RussianPeasantAlgorithm
{
#pragma warning disable CA1822 // Mark members as static
    public int Multiply(int x, int y)
#pragma warning restore CA1822 // Mark members as static
    {
        var result = 0;
        // While second number doesn't become 1 
        while (y > 0)
        {
            // If second number becomes odd, 
            // add the first number to result 
            if ((y & 1) != 0)
                result += x;

            // Double the first number 
            x <<= 1;
            // Half the second number
            y >>= 1;
        }

        return result;
    }
}