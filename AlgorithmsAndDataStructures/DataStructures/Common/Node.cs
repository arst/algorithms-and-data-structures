using System;

namespace AlgorithmsAndDataStructures.DataStructures.Common
{
    public class Node<T> where T: IEquatable<T>
    {
        public T Value { get; set; }

        public Node<T> Next { get; set; }
    }
}
