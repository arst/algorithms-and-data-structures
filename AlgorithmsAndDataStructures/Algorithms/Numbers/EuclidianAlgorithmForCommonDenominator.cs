namespace AlgorithmsAndDataStructures.Algorithms.Numbers
{
    public class EuclidianAlgorithmForCommonDenominator
    {
        public int CommonDenominator(int a, int b)
        {
            return b == 0 ? a : CommonDenominator(b, a % b);
        }
    }
}
