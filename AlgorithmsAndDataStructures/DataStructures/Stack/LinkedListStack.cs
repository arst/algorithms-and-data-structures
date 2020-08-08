using System;

namespace AlgorithmsAndDataStructures.DataStructures.Stack
{
    public class LinkedListStack<T>
    {
        LinkedListStackNode<T> head;

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
                throw new ArgumentException("Stack is Empty");
            }

            var value = head.Value;
            head = head.Next;
            return value;
        }

        public T Peak()
        {
            if (IsEmpty)
            {
                throw new ArgumentException("Stack is Empty");
            }
            return head.Value;
        }

        public bool IsEmpty => head == null;
    }
}
