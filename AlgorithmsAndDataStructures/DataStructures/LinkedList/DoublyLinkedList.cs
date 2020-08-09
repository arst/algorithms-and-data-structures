using AlgorithmsAndDataStructures.DataStructures.Common;
using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.DataStructures.LinkedList
{
    public class DoublyLinkedList<T> where T : IEquatable<T>
    {
        private DoublyNode<T> head;
        private DoublyNode<T> tail;

        public DoublyLinkedList(DoublyNode<T> node = null)
        {
            head = node;

            if (node != null)
            {
                tail = GetTail(head);
            }
        }

        private DoublyNode<T> GetTail(DoublyNode<T> head)
        {
            var current = head;

            while (current.Next != null)
            {
                current = current.Next;
            }

            return current;
        }

        public void Prepend(T value)
        {
            var newNode = new DoublyNode<T> { Value = value };

            if (IsEmpty())
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                head.Previous = newNode;
                newNode.Next = head;
                head = newNode;
            }
        }

        public void Append(T value)
        {
            var newNode = new DoublyNode<T> { Value = value };

            if (IsEmpty())
            {
                head = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Previous = tail;
                tail = newNode;
            }
        }

        public void RemoveByPosition(int position)
        {
            if (IsEmpty())
            {
                return;
            }

            if (position == 0)
            {
                head = head.Next;
                head.Previous = null;
                return;
            }

            var previous = head;
            var current = head.Next;
            var pointer = 1;

            while (pointer < position && current != null)
            {
                previous = current;
                current = current.Next;
                pointer++;
            }

            var nextInLine = current?.Next;

            previous.Next = nextInLine;

            if (nextInLine != null)
            {
                nextInLine.Previous = previous;
            }
        }

        private bool IsEmpty()
        {
            return head == null;
        }

        public List<T> Traverse()
        {
            var result = new List<T>();

            if (IsEmpty())
            {
                return result;
            }

            var current = head;

            while (current != null)
            {
                result.Add(current.Value);
                current = current.Next;
            }

            return result;
        }

        public void Reverse()
        {
            var node = ReverseRecursive(head);
            node.Next = null;
            head.Previous = node;
        }

        private DoublyNode<T> ReverseRecursive(DoublyNode<T> head)
        {
            if (head.Next == null)
            {
                head.Previous = null;
                this.head = head;

                return head;
            }

            var node = ReverseRecursive(head.Next);

            node.Next = head;
            head.Previous = node;

            return head;
        }

        public void SwapHeadAndTail()
        {
            var node = head;
            var previous = (DoublyNode<T>)null;

            while (node.Next != null)
            {
                previous = node;
                node = node.Next;
            }

            previous.Next = null;
            node.Previous = null;
            node.Next = head;
            head.Previous = node;
            head = node;
            
        }
    }
}
