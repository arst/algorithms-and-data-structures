using AlgorithmsAndDataStructures.DataStructures.BinaryHeap;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsAndDataStructures.Algorithms.Compression
{
    public class HuffmanCodeCompression
    {
#pragma warning disable CA1822 // Mark members as static
        public (BitArray Compressed, HuffmanCodeNode HuffmanEncodingTree) Compress(string target)
#pragma warning restore CA1822 // Mark members as static
        {
            if (string.IsNullOrEmpty(target))
            {
                return (new BitArray(0), null);
            }

            var frequencyMap = GetFrequencyMap(target);
            var frequencyHeap = BuildFrequencyMinHeap(frequencyMap);


            while (frequencyHeap.Size > 1)
            {
                var highestFrequency = frequencyHeap.GetTop();
                var secondHighestFrequency = frequencyHeap.GetTop();
                var combinedFrequency = highestFrequency.Frequency + secondHighestFrequency.Frequency;
                var combinedSubtree = CreateSubTree(combinedFrequency, highestFrequency, secondHighestFrequency);
                frequencyHeap.Insert(combinedSubtree);
            }

            var huffmanEncodingTree = frequencyHeap.GetTop();

            var huffmanEncodingMap = new Dictionary<char, List<bool>>();

            BuildEncodingMap(huffmanEncodingTree, huffmanEncodingMap, new List<bool>());

            var compressed = new List<bool>(target.Length);

            foreach (var symbol in target)
            {
                compressed.AddRange(huffmanEncodingMap[symbol]);
            }

            return (new BitArray(compressed.ToArray()), huffmanEncodingTree);
        }

#pragma warning disable CA1822 // Mark members as static
        public string Decompress(BitArray compressedTarget, HuffmanCodeNode huffmanEncodingTree)
#pragma warning restore CA1822 // Mark members as static
        {   
            var currentBitPointer = 0;
            var currentNode = huffmanEncodingTree;
            var resultBuilder = new StringBuilder(compressedTarget?.Length ?? 0);

            while (currentBitPointer <= compressedTarget?.Length)
            {
                if (currentNode?.Character.HasValue == true)
                {
                    resultBuilder.Append(currentNode.Character.Value);
                    currentNode = huffmanEncodingTree;
                }

                if (currentBitPointer == compressedTarget.Length)
                {
                    break;
                }

                var currentBit = compressedTarget[currentBitPointer];
                currentBitPointer++;
                currentNode = currentBit == false ? currentNode?.Left : currentNode?.Right;
            }

            return resultBuilder.ToString();
        }

        private static void BuildEncodingMap(HuffmanCodeNode huffmanEncodingTree, IDictionary<char, List<bool>> huffmanEncodingMap, List<bool> encoding)
        {
            if (huffmanEncodingTree is null)
            {
                return;
            }

            if (huffmanEncodingTree.Character.HasValue)
            {
                huffmanEncodingMap[huffmanEncodingTree.Character.Value] = encoding;
                return;
            }

            var leftEncoding = new List<bool>(encoding);
            var rightEncoding = new List<bool>(encoding);
            leftEncoding.Add(false);
            rightEncoding.Add(true);
            BuildEncodingMap(huffmanEncodingTree.Left, huffmanEncodingMap, leftEncoding);
            BuildEncodingMap(huffmanEncodingTree.Right, huffmanEncodingMap, rightEncoding);
        }

        private static HuffmanCodeNode CreateSubTree(int combinedFrequency, HuffmanCodeNode highestFrequency, HuffmanCodeNode secondHighestFrequency)
        {
            var combinedTreeHead = 
                new HuffmanCodeNode
                {
                    Frequency = combinedFrequency,
                    Left = highestFrequency,
                    Right = secondHighestFrequency
                };

            return combinedTreeHead;
        } 

        private static MinBinaryHeap<HuffmanCodeNode> BuildFrequencyMinHeap(Dictionary<char, int> frequencyMap)
        {
            var minHeap = new MinBinaryHeap<HuffmanCodeNode>(frequencyMap.Count);

            foreach (var frequency in frequencyMap)
            {
                minHeap.Insert(
                    new HuffmanCodeNode
                    { 
                        Character = frequency.Key,
                        Frequency = frequency.Value
                    });
            }

            return minHeap;
        }

        private static Dictionary<char, int> GetFrequencyMap(string target)
        {
            var frequencyMap = new Dictionary<char, int>();

            foreach (var character in target)
            {
                if(!frequencyMap.ContainsKey(character))
                {
                    frequencyMap.Add(character, 0);
                }

                frequencyMap[character] = frequencyMap[character] + 1;
            }

            return frequencyMap;
        }
    }
}
