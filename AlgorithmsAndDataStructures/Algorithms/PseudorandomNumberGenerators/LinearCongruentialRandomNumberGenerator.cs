namespace AlgorithmsAndDataStructures.Algorithms.PseudorandomNumberGenerators
{
    public class LinearCongruentialRandomNumberGenerator
    {
        // This value was proven to be a good candidate for a seed.
        private const long seed = 4294967296;
        // This value was proven to be a good candidate for a multiplier.
        private const int multiplier = 32310901;
        // This value has no particular recomendations, except for an oddity of this value.
        private const int increment = 321777;
        // This value has no particular recomendations, the only recomndation is that it should be a power of two. This one is Math.Pow(2, 26).
        private const int modulos = 67108864;

        private long lastGeneratedValue;

        public LinearCongruentialRandomNumberGenerator() => lastGeneratedValue = GenerateInternal(seed);

        public long Generate()
        {
            lastGeneratedValue = GenerateInternal(lastGeneratedValue);

            return lastGeneratedValue;
        }

        private static long GenerateInternal(long previous) => (multiplier * previous + increment) % modulos;
    }
}
