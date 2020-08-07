using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace AlgorithmsAndDataStructures.Algorithms.Compression
{
    public class LzwCompression
    {
#pragma warning disable CA1822 // Mark members as static
        public List<int> Compress(string input)
#pragma warning restore CA1822 // Mark members as static
        {
            if (string.IsNullOrEmpty(input))
            {
                return new List<int>(0);
            }

            var codeByNGramMap = new Dictionary<string, int>();
            
            // Fill up array with 1-n grams
            for (var i = 0; i < 256; i++)
            {
                codeByNGramMap.Add(((char)i).ToString(CultureInfo.InvariantCulture), i);
            }

            var temp = string.Empty;

            var compressed = new List<int>();

            foreach (var symbol in input)
            {
                var ngram = temp + symbol;

                if (codeByNGramMap.ContainsKey(ngram))
                {
                    temp = ngram;
                }
                else
                {
                    compressed.Add(codeByNGramMap[temp]);
                    codeByNGramMap[ngram] = codeByNGramMap.Count;

                    temp = symbol.ToString(CultureInfo.InvariantCulture);
                }
            }

            if (!string.IsNullOrEmpty(temp))
            {
                compressed.Add(codeByNGramMap[temp]);
            }

            return compressed;
        }

#pragma warning disable CA1822 // Mark members as static
        public string Decompress(List<int> compressed)
#pragma warning restore CA1822 // Mark members as static
        {
            if (compressed is null || compressed.Count == 0)
            {
                return string.Empty;
            }

            var nGramByCodeMap = new Dictionary<int, string>();

            // Fill up array with 1-n grams
            for (var i = 0; i < 256; i++)
                nGramByCodeMap.Add(i, ((char)i).ToString(CultureInfo.InvariantCulture));

            var current = nGramByCodeMap[compressed[0]];
            compressed.RemoveAt(0);
            var decompressed = new StringBuilder(current);

            foreach (var code in compressed)
            {
                var isAlreadyDecoded = nGramByCodeMap.TryGetValue(code, out var entry);

                if (!isAlreadyDecoded && code == nGramByCodeMap.Count)
                {
                    entry = current + current[0];
                }

                decompressed.Append(entry);

                if (entry != null)
                {
                    nGramByCodeMap.Add(nGramByCodeMap.Count, current + entry[0]);

                    current = entry;
                }
            }

            return decompressed.ToString();
        }
    }
}
