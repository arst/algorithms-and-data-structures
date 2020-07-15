using AlgorithmsAndDataStructures.DataStructures.BinaryHeap;
using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.Algorithms.Compression
{
    public class HuffmanCode
    {
        public void Compress(string target)
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
            var minHeap = new MinBinaryHeap<HuffmanCodeNode>();

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
