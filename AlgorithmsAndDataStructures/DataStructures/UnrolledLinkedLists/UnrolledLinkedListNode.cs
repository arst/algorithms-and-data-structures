namespace AlgorithmsAndDataStructures.DataStructures.UnrolledLinkedLists;

public class UnrolledLinkedListNode<T>
{
    public int CurrentIndex { get; set; }

#pragma warning disable CA1819 // Properties should not return arrays
    public T[] Values { get; set; } = new T[5];
#pragma warning restore CA1819 // Properties should not return arrays

    public UnrolledLinkedListNode<T> Next { get; set; }
}