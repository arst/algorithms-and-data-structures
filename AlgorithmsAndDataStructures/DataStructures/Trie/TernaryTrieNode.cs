namespace AlgorithmsAndDataStructures.DataStructures.Trie
{
    public class TernaryTrieNode
    {
        public char Value { get; set; }

        public TernaryTrieNode GreaterThanCurrentCharacter { get; set; }

        public TernaryTrieNode EqualToCurrentCharacter { get; set; }

        public TernaryTrieNode LessThanCurrentCharacter { get; set; }

        public bool IsWord { get; set; }
    }
}
