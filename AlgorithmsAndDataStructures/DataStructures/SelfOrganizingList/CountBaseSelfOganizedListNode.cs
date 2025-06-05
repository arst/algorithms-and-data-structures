namespace AlgorithmsAndDataStructures.DataStructures.SelfOrganizingList;

public class CountBaseSelfOganizedListNode<T>
{
    public T Value { get; set; }

    public int Count { get; set; }

    public CountBaseSelfOganizedListNode<T> Next { get; set; }
}