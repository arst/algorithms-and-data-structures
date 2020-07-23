using System;

namespace AlgorithmsAndDataStructures.Algorithms.Sampling
{
    // This is dummy source, for the purpose of demonstration. This can be stream of samples, lines from the file with unknow length etc.
    public class SampleSource
    {
        private readonly Random random = new Random();
        private readonly int maxSamples;
        private int generatedSamplesCounter;

        public SampleSource(int maxSamples)
        {
            this.maxSamples = maxSamples;
        }

        public int GetNext()
        {
            var r = random.Next();

            if (maxSamples == generatedSamplesCounter)
            {
                r *= -1;
            }

            generatedSamplesCounter++;
            
            return r;
        }
    }
}
