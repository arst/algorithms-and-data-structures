namespace AlgorithmsAndDataStructures.Algorithms
{
    public class EuclidianAlgorithmForCommonDenominator
    {
        public int CommnDenominator(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }

            return CommnDenominator(b, a % b);
        }
    }
}
