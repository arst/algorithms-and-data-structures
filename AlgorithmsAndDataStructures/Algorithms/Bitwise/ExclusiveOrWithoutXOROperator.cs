namespace AlgorithmsAndDataStructures.Algorithms.Bitwise
{
    public class ExclusiveOrWithoutXOROperator
    {
        public int XOR(int x, int y)
        {
            return (x | y) & (~x | ~y);
        }
    }
}
