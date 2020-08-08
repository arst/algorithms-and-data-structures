using System;

namespace AlgorithmsAndDataStructures.DataStructures.Queue
{
    public class LinkedListQueue<T>
    {
        LinkedListQueueNode<T> head;
        LinkedListQueueNode<T> tail;

        public void Enqueue(T value)
        {
            if (IsEmpty)
            {
                head = new LinkedListQueueNode<T> { Value = value };
                tail = head;
            }
            else
            { 
                tail.Next = new LinkedListQueueNode<T> { Value = value };
                tail = tail.Next;
            }
        }

        public T Dequeue()
        {
            if (IsEmpty)
            {
                throw new ArgumentException("Queue is empty");
            }

            var value = head.Value;
            head = head.Next;

            return value;
        }

        public bool IsEmpty => head == null;
    }
}
