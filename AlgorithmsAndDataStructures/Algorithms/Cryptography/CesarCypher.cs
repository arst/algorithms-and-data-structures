using System.Text;

namespace AlgorithmsAndDataStructures.Algorithms.Cryptography
{
    public class CesarCypher
    {
        public string Encode(string input, byte padding)
        {
            var resultBuilder = new StringBuilder(input.Length);

            foreach (var symbol in input)
            {
                resultBuilder.Append((char)((byte)symbol + padding));
            }

            return resultBuilder.ToString();
        }

        public string Decode(string input, byte padding)
        {
            var resultBuilder = new StringBuilder(input.Length);

            foreach (var symbol in input)
            {
                resultBuilder.Append((char)((byte)symbol - padding));
            }

            return resultBuilder.ToString();
        }
    }
}
