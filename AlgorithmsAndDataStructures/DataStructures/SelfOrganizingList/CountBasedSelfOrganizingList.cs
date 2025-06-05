﻿namespace AlgorithmsAndDataStructures.DataStructures.SelfOrganizingList;

public class CountBasedSelfOrganizingList<T>
{
    private CountBaseSelfOganizedListNode<T> tail;
    public CountBaseSelfOganizedListNode<T> Head { get; private set; }

    public void Add(T value)
    {
        if (Head is null)
        {
            Head = new CountBaseSelfOganizedListNode<T> { Value = value };
            tail = Head;
            return;
        }

        tail.Next = new CountBaseSelfOganizedListNode<T> { Value = value };
        tail = tail.Next;
    }

    public CountBaseSelfOganizedListNode<T> Get(T value)
    {
        if (Head is null) return null;
#pragma warning disable HAA0601 // Value type to reference type conversion causing boxing allocation
        if (Head.Value.Equals(value))
        {
#pragma warning restore HAA0601 // Value type to reference type conversion causing boxing allocation
            Head.Count += 1;

            return Head;
        }

        var current = Head.Next;
        var previous = Head;

        while (current != null)
        {
#pragma warning disable HAA0601 // Value type to reference type conversion causing boxing allocation
            if (current.Value.Equals(value))
#pragma warning restore HAA0601 // Value type to reference type conversion causing boxing allocation
            {
                previous.Next = current.Next;
                current.Next = Head;
                Head = current;
                Head.Count += 1;
                Sink();
                return current;
            }

            previous = current;
            current = current.Next;
        }

        return null;
    }

    private void Sink()
    {
        if (Head.Next is null) return;

        if (Head.Count < Head.Next.Count)
        {
            var next = Head.Next;
            Head.Next = next.Next;
            next.Next = Head;
            Head = next;
        }

        var current = Head.Next;
        var previous = Head;

        while (current?.Next != null)
        {
            if (current.Count < current.Next.Count) Swap(previous, current, current.Next);
            current = current.Next;
        }
    }

    private static void Swap(CountBaseSelfOganizedListNode<T> previous, CountBaseSelfOganizedListNode<T> current,
        CountBaseSelfOganizedListNode<T> next)
    {
        if (next is null) return;

        previous.Next = next;
        current.Next = next.Next;
        next.Next = current;
    }
}