using AlgorithmsAndDataStructures.DataStructures.BinaryHeap;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AlgorithmsAndDataStructures.Algorithms.Compression
{
    public class HuffmanCodeCompression
    {
        public (BitArray Compressed, HuffmanCodeNode HuffmanEncodingTree) Compress(string target)
        {
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

        public string Decompress(BitArray compressedTarget, HuffmanCodeNode huffmanEncodingTree)
        {   
            var currentBitPointer = 0;
            var currentNode = huffmanEncodingTree;
            var resultBuilder = new StringBuilder(compressedTarget.Length);

            while (currentBitPointer <= compressedTarget.Length)
            {
                if (currentNode.Character.HasValue)
                {
                    resultBuilder.Append(currentNode.Character);
                    currentNode = huffmanEncodingTree;
                }

                if (currentBitPointer == compressedTarget.Length)
                {
                    break;
                }

                var currentBit = compressedTarget[currentBitPointer];
                currentBitPointer++;
                if (currentBit == false)
                {
                    currentNode = currentNode.Left;
                }
                else
                {
                    currentNode = currentNode.Right;
                }
            }

            return resultBuilder.ToString();
        }

        private void BuildEncodingMap(HuffmanCodeNode huffmanEncodingTree, Dictionary<char, List<bool>> huffmanEncodingMap, List<bool> encoding)
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

        private HuffmanCodeNode CreateSubTree(int combinedFrequency, HuffmanCodeNode highestFrequency, HuffmanCodeNode secondHighestFrequency)
        {
            var combinedTreeHead = 
                new HuffmanCodeNode()
                {
                    Frequency = combinedFrequency,
                    Left = highestFrequency,
                    Right = secondHighestFrequency
                };

            return combinedTreeHead;
        } 

        private MinBinaryHeap<HuffmanCodeNode> BuildFrequencyMinHeap(Dictionary<char, int> frequencyMap)
        {
            var minHeap = new MinBinaryHeap<HuffmanCodeNode>(frequencyMap.Count);

            foreach (var frequency in frequencyMap)
            {
                minHeap.Insert(new HuffmanCodeNode()
                { 
                    Character = frequency.Key,
                    Frequency = frequency.Value
                });
            }

            return minHeap;
        }

        private Dictionary<char, int> GetFrequencyMap(string target)
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
