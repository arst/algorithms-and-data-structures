using System;

namespace AlgorithmsAndDataStructures.DataStructures.Stack
{
    public class LinkedListStack<T>
    {
        private LinkedListStackNode<T> head;

        public LinkedListStack()
        {
            head = null;
        }

        public void Push(T value)
        {
            if (head == null)
            {
                head = new LinkedListStackNode<T> { Value = value };
            }
            else
            {
                var node = new LinkedListStackNode<T> { Value = value };
                node.Next = head;
                head = node;
            }
        }

        public T Pop()
        {
            if (IsEmpty)
            {
#pragma warning disable CA1303 // Do not pass literals as localized parameters
                throw new ArgumentException("Stack is Empty");
#pragma warning restore CA1303 // Do not pass literals as localized parameters
            }

            var value = head.Value;
            head = head.Next;
            return value;
        }

        public T Peak()
        {
            if (IsEmpty)
            {
#pragma warning disable CA1303 // Do not pass literals as localized parameters
                throw new ArgumentException("Stack is Empty");
#pragma warning restore CA1303 // Do not pass literals as localized parameters
            }
            return head.Value;
        }

        public bool IsEmpty => head == null;
    }
}
