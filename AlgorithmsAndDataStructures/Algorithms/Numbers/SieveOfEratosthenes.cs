namespace AlgorithmsAndDataStructures.Algorithms.Numbers
{
    public class SieveOfEratosthenes
    {
#pragma warning disable CA1822 // Mark members as static
        public bool[] FindPrimesUpTo(int inclusiveUpperBound)
#pragma warning restore CA1822 // Mark members as static
        {
            var result = new bool[inclusiveUpperBound + 1];

            // since 0 and 1 aren't considered as prime numbers, we omit them
            for (var i = 2; i < result.Length; i++)
            {
                result[i] = true;
            }

            // We use i * i instead of i < Math.Sqrt(n) cause power is generally quicker then sqrt.
            
            for (var i = 2; i * i < inclusiveUpperBound; i++)
            {
                if (result[i])
                {
                    for (var j = i; j <= inclusiveUpperBound / i; j++)
                    {
                        result[j * i] = false;
                    }
                }
            }

            return result;
        }
    }
}
