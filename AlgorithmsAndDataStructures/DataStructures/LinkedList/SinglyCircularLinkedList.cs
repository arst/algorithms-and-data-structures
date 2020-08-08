using AlgorithmsAndDataStructures.DataStructures.Common;
using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.DataStructures.LinkedList
{
    public class SinglyCircularLinkedList<T> where T : IEquatable<T>
    {
#pragma warning disable CA1000 // Do not declare static members on generic types
        public static SinglyCircularLinkedList<T> FromSingleLinkedList(SinglyLinkedList<T> singleLinkedList)
#pragma warning restore CA1000 // Do not declare static members on generic types
        {
            if (singleLinkedList is null)
            {
                return new SinglyCircularLinkedList<T>();
            }

            var head = singleLinkedList.GetHead();
            var start = head;

            while (start?.Next != null)
            {
                start = start.Next;
            }

            if (start != null)
            {
                start.Next = head;
            }
            
            return new SinglyCircularLinkedList<T>(start);
        }

        private Node<T> end;

        public SinglyCircularLinkedList(Node<T> node = null)
        {
            end = node;
        }

        public void Enqueue(T value)
        {
            var newNode = new Node<T> { Value = value };

            if (IsEmpty())
            {
                end = newNode;
                end.Next = newNode;
            }
            else
            {
                var temp = end.Next;
                end.Next = newNode;
                end.Next.Next = temp;
                end = newNode;
            }
        }

        public Node<T> Dequeue()
        {
            if (IsEmpty())
            {
                return null;
            }

            var next = end?.Next;
            end.Next = next?.Next;

            if (next == end)
            {
                end = null;
            }

            return next;
        }

        public Node<T> GetFront()
        {
            return end?.Next;
        }

        public Node<T> GetRear()
        {
            return end;
        }

        public List<T> Traverse()
        {
            var result = new List<T>();

            if (IsEmpty())
            {
                return result;
            }

            var start = end.Next;

            while (start != end)
            {
                result.Add(start.Value);
                start = start.Next;
            }

            result.Add(end.Value);

            return result;
        }

        private bool IsEmpty()
        {
            return end == null;
        }
    }
}
