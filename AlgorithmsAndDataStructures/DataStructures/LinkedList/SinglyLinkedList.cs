using AlgorithmsAndDataStructures.DataStructures.Common;
using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.DataStructures.LinkedList
{
    public class SinglyLinkedList<T> where T : IEquatable<T>
    {
        Node<T> head;
        Node<T> tail;

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
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                this.tail.Next = newNode;
                this.tail = newNode;
            }
        }

        public void Prepend(T value)
        {
            var newNode = new Node<T> { Value = value };

            newNode.Next = this.head;

            this.head = newNode;
        }

        public void RemoveByPosition(int position)
        {
            if (IsEmpty())
            {
                return;
            }

            if (position == 0)
            {
                this.head = this.head.Next;
            }
            else
            {
                var currentPosition = 0;
                var node = this.head;
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
            return this.head == null;
        }

        public void RemoveByValue(T value)
        {
            if (!IsEmpty() && head.Value.Equals(value))
            {
                if (head.Next == null)
                {
                    this.head = null;
                }
                else
                {
                    this.head = head.Next;
                }

                return;
            }
            
            var current = head?.Next;
            var previous = head;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    previous.Next = current.Next;

                    if (current.Next == null)
                    {
                        this.tail = previous;
                    }

                    break;
                }

                previous = current;
                current = current.Next;
            }
        }

        public List<T> TraverseRecursive()
        {
            var result = new List<T>();

            if (IsEmpty())
            {
                return result;
            }

            TraverseRecursiveInternal(this.head, result);

            return result;
        }

        private void TraverseRecursiveInternal(Node<T> node, List<T> result)
        {
            result.Add(node.Value);

            if (node.Next == null)
            {
                return;
            }

            TraverseRecursiveInternal(node.Next, result);
        }

        public List<T> Traverse()
        {
            var result = new List<T>();
            var current = this.head;

            while (current != null)
            {
                result.Add(current.Value);
                current = current.Next;
            }

            return result;
        }

        public Node<T> GetHead()
        {
            return this.head;
        }

        public void ReverseIterative()
        {
            if (IsEmpty())
            {
                return;
            }

            var newTail = this.head;
            var previous = this.head;
            var current = previous.Next;

            while (current != null)
            {
                var tmp = current.Next;
                current.Next = previous;
                previous = current;
                current = tmp;
            }

            newTail.Next = null;
            this.head = previous;
            this.tail = newTail;
        }

        public void ReverseRecursive()
        {
            var start = this.head;

            this.tail = ReverseRecursiveInternal(start);
            this.tail.Next = null;
        }

        private Node<T> ReverseRecursiveInternal(Node<T> start)
        {
            if (start.Next == null)
            {
                this.head = start;
                return start;
            }

            var node = ReverseRecursiveInternal(start.Next);

            node.Next = start;

            return start;
        }
    }
}
