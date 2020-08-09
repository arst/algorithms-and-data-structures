namespace AlgorithmsAndDataStructures.Algorithms.Bitwise
{
    public class BiggerIntegerWithoutBranching
    {
#pragma warning disable CA1822 // Mark members as static
        public int GetBigger(int x, int y)
#pragma warning restore CA1822 // Mark members as static
        {
            const int bitSize = 8;

            // >> (sizeof(int) * bitSize - 1)) - if x - y is positive number then it would result in 0, 
            // if negative number than it would result in -1
            // In first case x + 0 is just x
            // In second case the result would be negative number which is the difference between y - x
            // x - (difference between y and x) is y
            return x - ((x - y) & ((x - y) >> (sizeof(int) * bitSize - 1)));
        }
    }
}
