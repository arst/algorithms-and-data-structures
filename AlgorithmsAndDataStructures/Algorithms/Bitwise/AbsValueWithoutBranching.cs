namespace AlgorithmsAndDataStructures.Algorithms.Bitwise
{
    public class AbsValueWithoutBranching
    {
#pragma warning disable CA1822 // Mark members as static
        public int Abs(int input)
#pragma warning restore CA1822 // Mark members as static
        {
            const int bitSize = 8;
            // This will create all 0 mask for positive numbers
            // and all 1 mask for negative numbers
            var mask = input >> (sizeof(int) * bitSize - 1);
            
            return (mask + input) ^ mask;
        }
    }
}
