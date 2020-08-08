using AlgorithmsAndDataStructures.Algorithms.Hashing;
using System.Collections;

namespace AlgorithmsAndDataStructures.Algorithms.Misc.BloomFilters
{
    public class BloomFilter
    {
        private readonly BitArray filter;
        private readonly int hashFunctionsSetSize;
        private readonly FowlerNollVo1ABasedHash hash; 

        public BloomFilter(byte hashFunctionsSetSize)
        {
            filter = new BitArray(int.MaxValue);
            this.hashFunctionsSetSize = hashFunctionsSetSize + 1;
            hash = new FowlerNollVo1ABasedHash();
        }

        public void Insert(string input)
        {
            for (byte i = 1; i < hashFunctionsSetSize; i++)
            {
                var bitPosition = hash.GetHash(input, i);
                filter.Set(bitPosition, true);
            }
        }

        public bool IsInBloomFilter(string input)
        {
            var result = true;

            for (byte i = 1; i < hashFunctionsSetSize; i++)
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
