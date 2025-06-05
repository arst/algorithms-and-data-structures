namespace AlgorithmsAndDataStructures.Algorithms.Bitwise;

public class ExclusiveOrWithoutXorOperator
{
#pragma warning disable CA1822 // Mark members as static
    public int Xor(int x, int y)
#pragma warning restore CA1822 // Mark members as static
    {
        return (x | y) & (~x | ~y);
    }
}