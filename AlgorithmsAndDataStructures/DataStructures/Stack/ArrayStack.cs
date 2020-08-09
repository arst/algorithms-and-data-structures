using System;

namespace AlgorithmsAndDataStructures.DataStructures.Stack
{
    public class ArrayStack<T>
    {
        private T[] stack;
        private int pointer;

        public ArrayStack(int initialCapacity = 8)
        {
            stack = new T[initialCapacity]; 
        }

        public void Push(T value)
        {
            if (pointer == stack.Length)
            {
                var newStack = new T[stack.Length * 2];
                Array.Copy(stack, 0, newStack, 0, stack.Length);
                stack = newStack;
            }

            stack[pointer] = value;
            pointer++;
        }

        public T Pop()
        {
            if (IsEmpty)
            {
#pragma warning disable CA1303 // Do not pass literals as localized parameters
                throw new ArgumentException("Stack is Empty");
#pragma warning restore CA1303 // Do not pass literals as localized parameters
            }

            var value = stack[pointer - 1];
            stack[pointer - 1] = default;
            pointer--;
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
            return stack[pointer - 1];
        }

        public bool IsEmpty => pointer == 0;
    }
}
