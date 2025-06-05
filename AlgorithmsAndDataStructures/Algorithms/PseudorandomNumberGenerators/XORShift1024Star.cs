namespace AlgorithmsAndDataStructures.Algorithms.PseudorandomNumberGenerators;

public class XorShift1024Star
{
    private readonly long[] seed;
    private int pointer;

    public XorShift1024Star()
    {
        var xOrShift64Star = new XorShift64Star();

        seed = new long[16];

        for (var i = 0; i < seed.Length; i++) seed[i] = xOrShift64Star.Generate();
    }

    public long Generate()
    {
        var firstSeed = seed[pointer];
        pointer = (pointer + 1) & 15;
        var secondSeed = seed[pointer];
        secondSeed ^= secondSeed << 31;
        secondSeed ^= secondSeed >> 11;
        firstSeed ^= firstSeed >> 30;

        seed[pointer] = firstSeed ^ secondSeed;

        return seed[pointer] * 1181783497276652981;
    }
}