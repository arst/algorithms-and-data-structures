using AlgorithmsAndDataStructures.Algorithms.Compression;
using System;
using System.Text;
using Xunit;

namespace AlgorithmsAndDataStructures.Tests.Algorithm.Compression
{
    public class HuffmanCodeCompressionTests
    {
        [Fact]
        public void OneChar()
        {
            var sut = new HuffmanCodeCompression();
            var input = "t";

            var compressionResults = sut.Compress(input);

            Assert.Equal(input, sut.Decompress(compressionResults.Compressed, compressionResults.HuffmanEncodingTree));
        }


        [Fact]
        public void TwoChars()
        {
            var sut = new HuffmanCodeCompression();
            var input = "te";

            var compressionResults = sut.Compress(input);

            Assert.Equal(input, sut.Decompress(compressionResults.Compressed, compressionResults.HuffmanEncodingTree));
        }


        [Fact]
        public void ThreeChars()
        {
            var sut = new HuffmanCodeCompression();
            var input = "tes";

            var compressionResults = sut.Compress(input);

            Assert.Equal(input, sut.Decompress(compressionResults.Compressed, compressionResults.HuffmanEncodingTree));
        }

        [Fact]
        public void LongString()
        {
            var sut = new HuffmanCodeCompression();
            var input = "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";

            var compressionResults = sut.Compress(input);

            Assert.Equal(input, sut.Decompress(compressionResults.Compressed, compressionResults.HuffmanEncodingTree));
        }

        [Fact]
        public void Fuzzy()
        {
            var sut = new HuffmanCodeCompression();
            var inputBulder = new StringBuilder();
            var random = new Random();
            var inputLength = 10000;
            var minSymbol = (byte)'0';
            var maxSymbol = (byte)'~';

            for (int i = 0; i < inputLength; i++)
            {
                inputBulder.Append((char)random.Next(minSymbol, maxSymbol));
            }

            var input = inputBulder.ToString();
            var compressed = sut.Compress(input);

            Assert.Equal(input, sut.Decompress(compressed.Compressed, compressed.HuffmanEncodingTree));
        }
    }
}
