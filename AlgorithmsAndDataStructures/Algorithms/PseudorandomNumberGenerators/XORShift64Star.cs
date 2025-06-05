namespace AlgorithmsAndDataStructures.Algorithms.PseudorandomNumberGenerators;

public class XorShift64Star
{
    // This value has the only requirement of not being zero.
    private const long Seed = 429496729667111;

    // This number is a part of an algorithm. 
    private const long Multiplier = 2685821657736338717;
    private long lastGeneratedValue;

    public XorShift64Star()
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
        var x = previous;
        x ^= x >> 12;
        x ^= x << 25;
        x ^= x >> 27;

        return x * Multiplier;
    }
}