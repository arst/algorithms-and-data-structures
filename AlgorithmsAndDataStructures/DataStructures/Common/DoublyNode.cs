using System;

namespace AlgorithmsAndDataStructures.DataStructures.Common;

public class DoublyNode<T> where T : IEquatable<T>
{
    public DoublyNode<T> Previous { get; set; }

    public T Value { get; set; }

    public DoublyNode<T> Next { get; set; }
}