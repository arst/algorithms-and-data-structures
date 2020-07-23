using System;

namespace AlgorithmsAndDataStructures.Algorithms.PseudorandomNumberGenerators
{
    public class XORShift64Star
    {

        // This value has the only requirement of not being zero.
        private const long seed = 429496729667111;
        // This number is a part of an algorithm. 
        private const long multiplier = 2685821657736338717;
        private long lastGeneratedValue;

        public XORShift64Star() => lastGeneratedValue = GenerateInternal(seed);

        public long Generate()
        {
            lastGeneratedValue = GenerateInternal(lastGeneratedValue);

            return lastGeneratedValue;
        }

        private static long GenerateInternal(long previous)
        {
            var x = previous;
            x ^= (x >> 12);
            x ^= (x << 25);
            x ^= (x >> 27);

            return x * multiplier;
        }
    }
}
