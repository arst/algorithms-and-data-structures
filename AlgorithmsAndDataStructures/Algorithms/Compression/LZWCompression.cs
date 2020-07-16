using System.Collections.Generic;
using System.Text;

namespace AlgorithmsAndDataStructures.Algorithms.Compression
{
    public class LZWCompression
    {
        public List<int> Compress(string input)
        {
            var codeByNGramMap = new Dictionary<string, int>();
            
            // Fill up array with 1-n grams
            for (int i = 0; i < 256; i++)
            {
                codeByNGramMap.Add(((char)i).ToString(), i);
            }

            string temp = string.Empty;

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

                    temp = symbol.ToString();
                }
            }

            if (!string.IsNullOrEmpty(temp))
            {
                compressed.Add(codeByNGramMap[temp]);
            }

            return compressed;
        }

        public string Decompress(List<int> compressed)
        {
            var nGramByCodeMap = new Dictionary<int, string>();

            // Fill up array with 1-n grams
            for (int i = 0; i < 256; i++)
                nGramByCodeMap.Add(i, ((char)i).ToString());

            string current = nGramByCodeMap[compressed[0]];
            compressed.RemoveAt(0);
            var decompressed = new StringBuilder(current);

            foreach (int code in compressed)
            {
                var isAlreadyDecoded = nGramByCodeMap.TryGetValue(code, out string entry);

                if (!isAlreadyDecoded && code == nGramByCodeMap.Count)
                {
                    entry = current + current[0];
                }

                decompressed.Append(entry);

                nGramByCodeMap.Add(nGramByCodeMap.Count, current + entry[0]);
                
                current = entry;
            }

            return decompressed.ToString();
        }
    }
}
