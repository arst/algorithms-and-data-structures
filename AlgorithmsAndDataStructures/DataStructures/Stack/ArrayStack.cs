using System;

namespace AlgorithmsAndDataStructures.DataStructures.Stack;

public class ArrayStack<T>
{
    private int pointer;
    private T[] stack;

    public ArrayStack(int initialCapacity = 8)
    {
        stack = new T[initialCapacity];
    }

    public bool IsEmpty => pointer == 0;

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
        if (IsEmpty) throw new ArgumentException("Stack is Empty");

        var value = stack[pointer - 1];
        stack[pointer - 1] = default;
        pointer--;
        return value;
    }

    public T Peak()
    {
        if (IsEmpty) throw new ArgumentException("Stack is Empty");
        return stack[pointer - 1];
    }
}