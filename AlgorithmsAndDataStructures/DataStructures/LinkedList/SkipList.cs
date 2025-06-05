using System;
using System.Collections.Generic;
using AlgorithmsAndDataStructures.DataStructures.Common;

namespace AlgorithmsAndDataStructures.DataStructures.LinkedList;

public class SkipList<T> where T : IComparable<T>
{
    private readonly int maxHeight;
    private readonly Random random = new();
    private readonly SkipListNode<T> sentinel;


    public SkipList(int maxHeight = 32)
    {
        sentinel = new SkipListNode<T> { Value = default, IsSentinelNode = true };
        this.maxHeight = maxHeight;
        var level = maxHeight - 1;
        var current = sentinel;

        while (level > 0)
        {
            current.Down = new SkipListNode<T> { Value = default, IsSentinelNode = true };
            current = current.Down;
            level--;
        }
    }

    public void Append(T value)
    {
        // TODO: This approach with path is ugly. Refactor to some recursive approach?
        var path = new SkipListNode<T>[maxHeight - 1];
        var counter = 0;
        var current = sentinel;

        while (current.Down != null)
        {
            while (current.Next != null && current.Next.Value.CompareTo(value) == -1) current = current.Next;

            if (current.Value.CompareTo(value) == -1 && current.Down != null)
            {
                path[counter] = current;
                counter++;
                current = current.Down;
            }
        }

        while (current.Next != null && current.Next.Value.CompareTo(value) == -1) current = current.Next;

        var nextInLine = current?.Next;
        current.Next = new SkipListNode<T> { Value = value };

        if (nextInLine != null) current.Next.Next = nextInLine;

        var levelsToAdd = 1;
        while (random.Next(2) == 1 && levelsToAdd < maxHeight) levelsToAdd++;

        var below = current.Next;
        for (var i = levelsToAdd - 2; i >= 0 && path[i] != null; i--)
        {
            nextInLine = path[i]?.Next;
            path[i].Next = new SkipListNode<T> { Value = value, Down = below };

            if (nextInLine != null) path[i].Next.Next = nextInLine;
        }
    }

    public void PintSkipList()
    {
        var stack = new Stack<string>(maxHeight);
        var sentinels = new Stack<SkipListNode<T>>(maxHeight);
        var lineStarter = sentinel;
        while (lineStarter != null)
        {
            sentinels.Push(lineStarter);
            lineStarter = lineStarter.Down;
        }

        while (sentinels.Count > 0)
        {
            var currentLineStarter = sentinels.Pop();
            var line = string.Empty;
            while (currentLineStarter != null)
            {
#pragma warning disable HAA0202 // Value type to reference type conversion allocation for string concatenation
                line += currentLineStarter.Value + " ";
#pragma warning restore HAA0202 // Value type to reference type conversion allocation for string concatenation
                currentLineStarter = currentLineStarter.Next;
            }

            stack.Push(line);
        }

        foreach (var line in stack) Console.WriteLine(line);

        var final = string.Join(Environment.NewLine, stack.ToArray());

        Console.WriteLine(final);
    }
}