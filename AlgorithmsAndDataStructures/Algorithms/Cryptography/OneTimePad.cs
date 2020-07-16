using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AlgorithmsAndDataStructures.Algorithms.Cryptography
{
    public class OneTimePad
    {
        public (string Pad, string Encoded) Encode(string input)
        {
            var bitsString = ToBinaryString(Encoding.ASCII, input);
            var oneTimePad = GetOneTimePad(bitsString);
            var resultBuilder = new StringBuilder(bitsString.Length);

            for (int i = 0; i < bitsString.Length; i++)
            {
                var inputBit = bitsString[i] == '1' ? true : false;
                var oneTimePadBit = oneTimePad[i] == '1' ? true : false;
                resultBuilder.Append(inputBit ^ oneTimePadBit ? '1' : '0');    
            }

            return (Pad: oneTimePad, Encoded: resultBuilder.ToString());
        }

        public string Decode(string pad, string encoded)
        {
            var resultBuilder = new StringBuilder(pad.Length);

            for (int i = 0; i < encoded.Length; i++)
            {
                var inputBit = encoded[i] == '1' ? true : false;
                var oneTimePadBit = pad[i] == '1' ? true : false;
                resultBuilder.Append(inputBit ^ oneTimePadBit ? '1' : '0');
            }

            return DecodeBinaryString(resultBuilder.ToString());
        }

        private static string DecodeBinaryString(string input)
        {
            var bytes = new List<byte>();
            var inputSpan = input.AsSpan();

            for (int i = 0; i < input.Length; i += 8)
            {
                var temp = inputSpan.Slice(i, 8);

                // There must be a way to get bytes without converting span back to string
                bytes.Add(Convert.ToByte(temp.ToString(), 2));
            }

            return Encoding.ASCII.GetString(bytes.ToArray());
        }

        private static string GetOneTimePad(string bitsString)
        {
            var randomBytes = new byte[bitsString.Length];
            using var random = new RNGCryptoServiceProvider();
            random.GetBytes(randomBytes);

            return string.Join("", randomBytes.Select(n => Convert.ToString(n, 2).PadLeft(8, '0')));
        }

        private static string ToBinaryString(Encoding encoding, string text)
        {
            return string.Join("", encoding.GetBytes(text).Select(n => Convert.ToString(n, 2).PadLeft(8, '0')));
        }
    }
}
