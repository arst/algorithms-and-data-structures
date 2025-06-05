namespace AlgorithmsAndDataStructures.DataStructures.Trie;

public class AlphabetTrieNode
{
#pragma warning disable CA1819 // Properties should not return arrays
    public AlphabetTrieNode[] Children { get; set; }
#pragma warning restore CA1819 // Properties should not return arrays

    public bool IsCompleteWord { get; set; }
}