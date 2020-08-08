using System;

namespace AlgorithmsAndDataStructures.DataStructures.BinaryTree
{
    public class ArrayBinaryTree<T>
    {
        private T[] tree;

        public ArrayBinaryTree(int initialCapacity = 8)
        {
            tree = new T[initialCapacity + 1];
        }

        public void Root(T value)
        {
            tree[1] = value;
        }

        public void SetLeft(T parent, T value)
        {
            for (var i = 0; i < tree.Length; i++)
            {
#pragma warning disable HAA0601 // Value type to reference type conversion causing boxing allocation
                if (tree[i].Equals(parent))
#pragma warning restore HAA0601 // Value type to reference type conversion causing boxing allocation
                {
                    var leftIndex = i * 2;

                    if (leftIndex >= tree.Length)
                    {
                        ExpandTree();
                    }

                    tree[leftIndex] = value;
                }
            }
        }

        public void SetRight(T parent, T value)
        {
            for (var i = 0; i < tree.Length; i++)
            {
#pragma warning disable HAA0601 // Value type to reference type conversion causing boxing allocation
                if (tree[i].Equals(parent))
#pragma warning restore HAA0601 // Value type to reference type conversion causing boxing allocation
                {
                    var rightIndex = i * 2 + 1;

                    if (rightIndex >= tree.Length)
                    {
                        ExpandTree();
                    }

                    tree[rightIndex] = value;
                }
            }
        }

        private void ExpandTree()
        {
            var expandedTree = new T[tree.Length * 2];

            Array.Copy(tree, 0, expandedTree, 0, tree.Length);

            tree = expandedTree;
        }

        public T[] GetTree() => tree;
        
    }
}
