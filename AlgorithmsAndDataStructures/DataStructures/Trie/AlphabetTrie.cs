using System.Linq;

namespace AlgorithmsAndDataStructures.DataStructures.Trie
{
    public class AlphabetTrie
    {
        private readonly int alphabetSize;
        private readonly int alphabetStart;
        AlphabetTrieNode root;

        public AlphabetTrie(int alphabetSize = 26)
        {
            this.alphabetSize = alphabetSize;
            alphabetStart = 'a';
        }

        public void Insert(string key)
        {
            root ??= new AlphabetTrieNode {Children = new AlphabetTrieNode[alphabetSize]};

            var current = root;

            for (var i = 0; i < key?.Length; i++)
            {
                var index = GetIndex(key, i);

                current.Children[index] ??= new AlphabetTrieNode {Children = new AlphabetTrieNode[alphabetSize]};

                current = current.Children[index];
            }

            current.IsCompleteWord = true;
        }

        public bool Search(string key)
        {
            if (root == null)
            {
                return false;
            }

            var current = root;

            for (var i = 0; i < key?.Length; i++)
            {
                var index = GetIndex(key, i);

                if (current.Children[index] == null)
                {
                    return false;
                }

                current = current.Children[index];
            }

            return (current != null && current.IsCompleteWord);
        }

        private int GetIndex(string key, int position)
        {
            return key[position] - alphabetStart;
        }

        public void Delete(string key)
        {
            root = DeleteInternal(root, key);
        }

        private AlphabetTrieNode DeleteInternal(AlphabetTrieNode node, string key)
        {
            if (node == null || string.IsNullOrEmpty(key))
            {
                return null;
            }

            var index = GetIndex(key, 0);

            if (key.Length == 1 && node.Children?[index] != null)
            {
                if (node.Children?[index].IsCompleteWord == true)
                {
                    if (node.Children?[index].Children?.Any(arg => arg != null) == true)
                    {
                        node.IsCompleteWord = false;
                        return node;
                    }

                    node.Children[index] = null;
                    return IsNonEmptyNode(node) ? node : null;
                }

                return node;
            }

            node.Children[index] = DeleteInternal(node.Children[index], key.Substring(1));

            return IsNonEmptyNode(node) ? node : null;

        }

        private static bool IsNonEmptyNode(AlphabetTrieNode node)
        {
            return node.Children.Any(arg => arg != null) || node.IsCompleteWord;
        }
    }
}
