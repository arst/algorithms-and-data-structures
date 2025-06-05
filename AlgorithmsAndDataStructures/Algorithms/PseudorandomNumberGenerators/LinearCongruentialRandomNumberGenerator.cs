namespace AlgorithmsAndDataStructures.Algorithms.PseudorandomNumberGenerators;

public class LinearCongruentialRandomNumberGenerator
{
    // This value was proven to be a good candidate for a seed.
    private const long Seed = 4294967296;

    // This value was proven to be a good candidate for a multiplier.
    private const int Multiplier = 32310901;

    // This value has no particular recommendations, except for an oddity of this value.
    private const int Increment = 321777;

    // This value has no particular recommendations, the only recommendation is that it should be a power of two. This one is Math.Pow(2, 26).
    private const int Modulos = 67108864;

    private long lastGeneratedValue;

    public LinearCongruentialRandomNumberGenerator()
    {
        lastGeneratedValue = GenerateInternal(Seed);
    }

    public long Generate()
    {
        lastGeneratedValue = GenerateInternal(lastGeneratedValue);

        return lastGeneratedValue;
    }

    private static long GenerateInternal(long previous)
    {
        return (Multiplier * previous + Increment) % Modulos;
    }
}