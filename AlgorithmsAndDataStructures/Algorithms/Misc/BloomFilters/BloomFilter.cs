using AlgorithmsAndDataStructures.Algorithms.Hashing;
using System.Collections;

namespace AlgorithmsAndDataStructures.Algorithms.Misc.BloomFilters
{
    public class BloomFilter
    {
        private readonly BitArray filter;
        private readonly int hashfunctionsSetSize;
        private readonly FowlerNollVo1aBasedHash hash; 

        public BloomFilter(byte hashfunctionsSetSize)
        {
            filter = new BitArray(int.MaxValue);
            this.hashfunctionsSetSize = hashfunctionsSetSize + 1;
            hash = new FowlerNollVo1aBasedHash();
        }

        public void Insert(string input)
        {
            for (byte i = 1; i < hashfunctionsSetSize; i++)
            {
                var bitPosition = hash.GetHash(input, i);
                filter.Set(bitPosition, true);
            }
        }

        public bool IsInBloomFilter(string input)
        {
            var result = true;

            for (byte i = 1; i < hashfunctionsSetSize; i++)
            {
                var bitPosition = hash.GetHash(input, i);
                result = filter.Get(bitPosition);

                if (!result)
                {
                    break;
                }
            }

            return result;
        }
    }
}
