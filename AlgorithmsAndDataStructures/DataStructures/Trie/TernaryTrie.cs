using System;

namespace AlgorithmsAndDataStructures.DataStructures.Trie;

public class TernaryTrie
{
    private TernaryTrieNode root;

    public void Insert(string key)
    {
        if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));

        root = InsertInternal(key, 0, root);
    }

    private static TernaryTrieNode InsertInternal(string key, int index, TernaryTrieNode currentNode)
    {
        var node = currentNode ?? new TernaryTrieNode
        {
            Value = key[index]
        };

        if (key.Length == index + 1 && node.Value == key[index])
        {
            node.IsWord = true;
        }
        else
        {
            if (node.Value == key[index])
                node.EqualToCurrentCharacter = InsertInternal(key, index + 1, node.EqualToCurrentCharacter);
            else if (node.Value < key[index])
                node.GreaterThanCurrentCharacter = InsertInternal(key, index, node.GreaterThanCurrentCharacter);
            else
                node.LessThanCurrentCharacter = InsertInternal(key, index, node.LessThanCurrentCharacter);
        }

        return node;
    }

    public bool Search(string key)
    {
        if (string.IsNullOrEmpty(key)) return default;

        if (root == null) return false;

        return SearchInternal(key, 0, root);
    }

    private static bool SearchInternal(string key, int index, TernaryTrieNode currentNode)
    {
        if (currentNode == null) return false;

        var isEqual = currentNode.Value == key[index];
        var isEndSymbol = index == key.Length - 1;

        if (isEqual)
        {
            if (isEndSymbol) return currentNode.IsWord;

            return SearchInternal(key, index + 1, currentNode.EqualToCurrentCharacter);
        }

        var isBigger = currentNode.Value < key[index];

        if (isBigger) return SearchInternal(key, index, currentNode.GreaterThanCurrentCharacter);

        return SearchInternal(key, index, currentNode.LessThanCurrentCharacter);
    }

    public void Delete(string key)
    {
        if (string.IsNullOrEmpty(key)) return;

        root = DeleteInternal(key, 0, root);
    }

    private TernaryTrieNode DeleteInternal(string key, int index, TernaryTrieNode currentNode)
    {
        if (currentNode == null) return null;

        if (currentNode.Value == key[index])
        {
            if (index == key.Length - 1)
            {
                currentNode.IsWord = false;

                return IsEmptyNode(currentNode) ? null : currentNode;
            }

            currentNode.EqualToCurrentCharacter = DeleteInternal(key, index + 1, currentNode.EqualToCurrentCharacter);
        }
        else if (currentNode.Value < key[index])
        {
            currentNode.GreaterThanCurrentCharacter =
                DeleteInternal(key, index, currentNode.GreaterThanCurrentCharacter);
        }
        else
        {
            currentNode.LessThanCurrentCharacter = DeleteInternal(key, index, currentNode.LessThanCurrentCharacter);
        }

        return currentNode;
    }

    private static bool IsEmptyNode(TernaryTrieNode currentNode)
    {
        return currentNode.EqualToCurrentCharacter != null
               || currentNode.GreaterThanCurrentCharacter != null
               || currentNode.LessThanCurrentCharacter != null;
    }
}