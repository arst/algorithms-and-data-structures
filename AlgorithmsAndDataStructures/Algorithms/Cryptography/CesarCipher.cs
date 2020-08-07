using System.Text;

namespace AlgorithmsAndDataStructures.Algorithms.Cryptography
{
    public class CesarCipher
    {
#pragma warning disable CA1822 // Mark members as static
        public string Encode(string input, byte padding)
#pragma warning restore CA1822 // Mark members as static
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            var resultBuilder = new StringBuilder(input.Length);

            foreach (var symbol in input)
            {
                resultBuilder.Append((char)((byte)symbol + padding));
            }

            return resultBuilder.ToString();
        }

#pragma warning disable CA1822 // Mark members as static
        public string Decode(string input, byte padding)
#pragma warning restore CA1822 // Mark members as static
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            var resultBuilder = new StringBuilder(input.Length);

            foreach (var symbol in input)
            {
                resultBuilder.Append((char)((byte)symbol - padding));
            }

            return resultBuilder.ToString();
        }
    }
}
