using System;
using System.Collections.Generic;
using AlgorithmsAndDataStructures.DataStructures.Common;

namespace AlgorithmsAndDataStructures.DataStructures.LinkedList;

public class SinglyLinkedList<T> where T : IEquatable<T>
{
    private Node<T> head;
    private Node<T> tail;

    public SinglyLinkedList(Node<T> head = null)
    {
        this.head = head;
        tail = head;
    }

    public void Append(T value)
    {
        var newNode = new Node<T> { Value = value };

        if (IsEmpty())
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            tail = newNode;
        }
    }

    public void Prepend(T value)
    {
        var newNode = new Node<T> { Value = value, Next = head };


        head = newNode;
    }

    public void RemoveByPosition(int position)
    {
        if (IsEmpty()) return;

        if (position == 0)
        {
            head = head.Next;
        }
        else
        {
            var currentPosition = 0;
            var node = head;
            Node<T> previous = null;

            while (currentPosition < position && node != null)
            {
                previous = node;
                node = node.Next;
                currentPosition++;
            }

            previous.Next = node?.Next;
        }
    }

    private bool IsEmpty()
    {
        return head == null;
    }

    public void RemoveByValue(T value)
    {
        if (!IsEmpty() && head.Value.Equals(value))
        {
            head = head.Next ?? null;

            return;
        }

        var current = head?.Next;
        var previous = head;

        while (current != null)
        {
            if (current.Value.Equals(value))
            {
                previous.Next = current.Next;

                if (current.Next == null) tail = previous;

                break;
            }

            previous = current;
            current = current.Next;
        }
    }

    public List<T> TraverseRecursive()
    {
        var result = new List<T>();

        if (IsEmpty()) return result;

        TraverseRecursiveInternal(head, result);

        return result;
    }

    private void TraverseRecursiveInternal(Node<T> node, List<T> result)
    {
        result.Add(node.Value);

        if (node.Next == null) return;

        TraverseRecursiveInternal(node.Next, result);
    }

    public List<T> Traverse()
    {
        var result = new List<T>();
        var current = head;

        while (current != null)
        {
            result.Add(current.Value);
            current = current.Next;
        }

        return result;
    }

    public Node<T> GetHead()
    {
        return head;
    }

    public void ReverseIterative()
    {
        if (IsEmpty()) return;

        var newTail = head;
        var previous = head;
        var current = previous.Next;

        while (current != null)
        {
            var tmp = current.Next;
            current.Next = previous;
            previous = current;
            current = tmp;
        }

        newTail.Next = null;
        head = previous;
        tail = newTail;
    }

    public void ReverseRecursive()
    {
        var start = head;

        tail = ReverseRecursiveInternal(start);
        tail.Next = null;
    }

    private Node<T> ReverseRecursiveInternal(Node<T> start)
    {
        if (start.Next == null)
        {
            head = start;
            return start;
        }

        var node = ReverseRecursiveInternal(start.Next);

        node.Next = start;

        return start;
    }
}