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
                this.head = new LinkedListQueueNode<T>() { Value = value };
                this.tail = this.head;
            }
            else
            { 
                this.tail.Next = new LinkedListQueueNode<T>() { Value = value };
                this.tail = this.tail.Next;
            }
        }

        public T Dequeue()
        {
            if (IsEmpty)
            {
                throw new ArgumentException("Queue is empty");
            }

            var value = this.head.Value;
            this.head = this.head.Next;

            return value;
        }

        public bool IsEmpty => head == null;
    }
}
