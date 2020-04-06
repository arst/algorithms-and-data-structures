namespace AlgorithmsAndDataStructures.Algorithms.Bitwise
{
    public class AbsValueWithoutBranching
    {
        public int Abs(int input)
        {
            // This will create all 0 mask for positive numbers
            // and all 1 mask for negative numbers
            int mask = input >> (sizeof(int) * 8 - 1);
            
            return (mask + input) ^ mask;
        }
    }
}
