namespace AlgorithmsAndDataStructures.Algorithms.Bitwise
{
    public class CountSetBitsInallNumbersUpToN
    {
        public int Count(int n)
        {
            var result = 0;

            for (int i = 1; i < n; i++)
            {
                result += CountBits(i);
            }

            return result;
        }

        private static int CountBits(int number)
        {
            if (number <= 0)
            {
                return 0;
            }
            else
            {
                return (number % 2 == 0 ? 0 : 1) + CountBits(number / 2);
            }
        }
    }
}
