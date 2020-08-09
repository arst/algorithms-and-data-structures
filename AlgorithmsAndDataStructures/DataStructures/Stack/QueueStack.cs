using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.DataStructures.Stack
{
    public class QueueStack<T>
    {
        private readonly Queue<T> leftQueue;
        private readonly Queue<T> rightQueue;

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
#pragma warning disable CA1303 // Do not pass literals as localized parameters
                throw new ArgumentException("Stack is Empty");
#pragma warning restore CA1303 // Do not pass literals as localized parameters
            }

            return GetPopQueue().Dequeue();
        }

        public T Peak()
        {
            if (IsEmpty)
            {
#pragma warning disable CA1303 // Do not pass literals as localized parameters
                throw new ArgumentException("Stack is Empty");
#pragma warning restore CA1303 // Do not pass literals as localized parameters
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

#pragma warning disable CA1303 // Do not pass literals as localized parameters
            throw new ArgumentException("Stack is Empty");
#pragma warning restore CA1303 // Do not pass literals as localized parameters
        }

        public bool IsEmpty => rightQueue.Count == 0 && leftQueue.Count == 0;
    }
}
