using System;

namespace AlgorithmsAndDataStructures.DataStructures.SuffixArray
{
    class EfficientSuffixArrayNode : IComparable
    {
        private string input;

        public EfficientSuffixArrayNode(string input)
        {
            this.input = input;
        }

        public string Suffix => input.Substring(Index);

        public int Index { get; set; }

        public int Rank { get; set; }

        public int NextRank { get; set; }

        public int CompareTo(object obj)
        {
            var node = obj as EfficientSuffixArrayNode;

            if (node.Rank != this.Rank)
            {
                return this.Rank.CompareTo(node.Rank);
            }

            return this.NextRank.CompareTo(node.NextRank);
        }
    }
}
