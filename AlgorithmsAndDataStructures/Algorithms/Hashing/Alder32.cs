using System;
using System.Security.Cryptography;

namespace AlgorithmsAndDataStructures.Algorithms.Hashing
{
    /*
        The Adler32 algorithm is not suitable for cryptographic uses because it produces hash codes that are susceptible to attack. 
        Adler32 produces short hash codes that easily succumb to birthday attacks and, more importantly, it is easy to generate a message that results in a specific Adler32 hash code. 

        The sole purpose of this implementation is to check how it is like to implement hashing algorithm based on common .NET abstractions
    */
    public class Alder32 : HashAlgorithm
    {
        private ushort sum1;
        private ushort sum2;
        private const int Modulo = 65521;

        public override void Initialize()
        {
            /*
             * Define a 16-bit value called Sum1 with an initial value of 1.
             * Define a 16-bit value called Sum2 with an initial value of 0.
             */
            sum1 = 1;
            sum2 = 0;
        }

        protected override void HashCore(byte[] array, int ibStart, int cbSize)
        {
            /*
             * Process each 8-bit message block in turn:
             * Add the numeric value of the message block to Sum 1, modulo 65521.
             * Add the value of Sum 1 to Sum 2, modulo 65521.
             */
            var endIndex = ibStart + cbSize;

            for (var i = ibStart; i < endIndex; i++)
            {
                sum1 = (ushort)((sum1 + array[i]) % Modulo);
                sum2 = (ushort)((sum1 + sum2) % Modulo);
            }
        }

        protected override byte[] HashFinal()
        {
            // Concatenate Sum 2 and Sum 1 together to create a 32-bit hash code.
            // concat the two 16 bit values to form one 32-bit value
            var result = (uint)((sum2 << 16) | sum1);

            var resultBytes = BitConverter.GetBytes(result);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(resultBytes);
            }

            return resultBytes;
        }
    }
}
