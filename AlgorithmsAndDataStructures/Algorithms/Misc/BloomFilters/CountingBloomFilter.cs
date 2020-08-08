using AlgorithmsAndDataStructures.Algorithms.Hashing;

namespace AlgorithmsAndDataStructures.Algorithms.Misc.BloomFilters
{
    public class CountingBloomFilter
    {
        private readonly int[] filter;
        private readonly int hashFunctionsSetSize;
        private readonly FowlerNollVo1aBasedHash hash;
        private readonly int filterSize;

        public CountingBloomFilter(int filterSize, byte hashFunctionsSetSize)
        {
            filter = new int[filterSize];
            this.hashFunctionsSetSize = hashFunctionsSetSize + 1;
            hash = new FowlerNollVo1aBasedHash();
            this.filterSize = filterSize;
        }

        public void Insert(string input)
        {
            for (byte i = 1; i < hashFunctionsSetSize; i++)
            {
                var bitPosition = hash.GetHash(input, i);
                filter[bitPosition % filterSize]++;
            }
        }

        public bool IsInBloomFilter(string input)
        {
            var result = true;

            for (byte i = 1; i < hashFunctionsSetSize; i++)
            {
                var bitPosition = hash.GetHash(input, i);
                result = filter[bitPosition % filterSize] > 0;

                if (!result)
                {
                    break;
                }
            }

            return result;
        }

        public void RemoveFromFilter(string input)
        {
            for (byte i = 1; i < hashFunctionsSetSize; i++)
            {
                var bitPosition = hash.GetHash(input, i);

                if (filter[bitPosition % filterSize] > 0)
                {
                    filter[bitPosition % filterSize]--;
                }
            }
        }
    }
}
