using System;

namespace AlgorithmsAndDataStructures.Algorithms.Numbers
{
    public class SieveOfEratosthenes
    {
        public bool[] FindPrimesUpTo(int inclusiveUpperBound)
        {
            var result = new bool[inclusiveUpperBound + 1];

            // since 0 and 1 aren't considered as prime numbers, we omit them
            for (int i = 2; i < result.Length; i++)
            {
                result[i] = true;
            }

            // We use i * i instead of i < Math.Sqrt(n) cause power is generally quicker then sqrt.
            
            for (int i = 2; i * i < inclusiveUpperBound; i++)
            {
                if (result[i] == true)
                {
                    for (int j = i; j <= inclusiveUpperBound / i; j++)
                    {
                        result[j * i] = false;
                    }
                }
            }

            return result;
        }
    }
}
