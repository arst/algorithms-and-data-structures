namespace AlgorithmsAndDataStructures.DataStructures.UnrolledLinkedList
{
    public class UnrolledLinkedListNode<T>
    {
        public int CurrentIndex { get; set; }

        public T[] Values { get; set; } = new T[5];

        public UnrolledLinkedListNode<T> Next { get; set; }
    }
}
