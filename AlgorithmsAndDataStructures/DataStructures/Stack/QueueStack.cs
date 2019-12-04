using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.DataStructures.Stack
{
    public class QueueStack<T>
    {
        private Queue<T> leftQueue;
        private Queue<T> rightQueue;

        public QueueStack()
        {
            leftQueue = new Queue<T>();
            rightQueue = new Queue<T>();
        }

        public void Push(T value)
        {
            if (leftQueue.Count > 0)
            {
                leftQueue.Enqueue(value);
            }
            else if (rightQueue.Count > 0)
            {
                rightQueue.Enqueue(value);
            }
            else
            {
                leftQueue.Enqueue(value);
            }
        }

        public T Pop()
        {
            if (IsEmpty)
            {
                throw new ArgumentException("Stack is Empty");
            }

            return GetPopQueue().Dequeue();
        }

        public T Peak()
        {
            if (IsEmpty)
            {
                throw new ArgumentException("Stack is Empty");
            }

            return GetPopQueue().Peek();
        }

        private Queue<T> GetPopQueue()
        {
            if (leftQueue.Count > 0)
            {
                while (leftQueue.Count > 1)
                {
                    rightQueue.Enqueue(leftQueue.Dequeue());
                }

                return leftQueue;
            }
            else if (rightQueue.Count > 0)
            {
                while (rightQueue.Count > 1)
                {
                    leftQueue.Enqueue(rightQueue.Dequeue());
                }

                return rightQueue;
            }

            throw new ArgumentException("Stack is Empty");
        }

        public bool IsEmpty => rightQueue.Count == 0 && leftQueue.Count == 0;
    }
}
