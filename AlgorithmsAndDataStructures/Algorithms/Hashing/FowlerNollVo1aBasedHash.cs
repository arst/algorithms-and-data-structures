namespace AlgorithmsAndDataStructures.Algorithms.Hashing
{
    public class FowlerNollVo1aBasedHash
    {
        // This is a good function to be used in bloom filters cause it allows us to create different hash functions by just changing the value of the seed.
#pragma warning disable CA1822 // Mark members as static
        public int GetHash(string input, int seed)
#pragma warning restore CA1822 // Mark members as static
        {
            if (string.IsNullOrEmpty(input))
            {
                return default;
            }

            const uint h = 0x811C9DC5;
            const int p = 0x01000193;

            var z = h ^ seed;

            foreach (var symbol in input)
            {
                z ^= symbol;
                z = (z * p) & 0xFFFFFFF;
            }

            return (int)z;
        }
    }
}
