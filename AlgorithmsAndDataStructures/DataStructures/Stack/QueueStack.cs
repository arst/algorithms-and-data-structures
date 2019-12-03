using System;
using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.DataStructures.Stack
{
    public class QueueStack<T>
    {
        private Queue<T> pushQueue;
        private Queue<T> popQueue;

        public QueueStack()
        {
            pushQueue = new Queue<T>();
            popQueue = new Queue<T>();
        }

        public void Push(T value)
        {
            
        }

        public T Pop()
        {
            return default;
        }

        public T Peak()
        {
            return default;
        }

        public bool IsEmpty => default;
    }
}
