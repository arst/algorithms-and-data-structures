﻿using System;

namespace AlgorithmsAndDataStructures.DataStructures.Queue;

public class CircularQueue<T>
{
    private readonly T[] queue;
    private int front = -1;
    private int rear = -1;

    public CircularQueue(int initialCapacity = 8)
    {
        queue = new T[initialCapacity];
    }

    public bool IsEmpty => front == -1;

    public void Enqueue(T value)
    {
        if ((rear == queue.Length - 1 && front == 0) || rear == front - 1) throw new ArgumentException("Queue is full");

        if (rear == -1 && front == -1)
        {
            front = 0;
            rear++;
            queue[rear] = value;
        }
        else
        {
            if (rear == queue.Length - 1 && front != 0)
            {
                rear = 0;
                queue[rear] = value;
            }
            else
            {
                rear++;
                queue[rear] = value;
            }
        }
    }

    public T Dequeue()
    {
        if (front == -1) throw new ArgumentException("Queue is empty");

        if (front == rear)
        {
            var tmp = queue[front];
            front = -1;
            rear = -1;
            return tmp;
        }

        if (front == queue.Length - 1)
        {
            var tmp = queue[front];
            front = 0;

            return tmp;
        }
        else
        {
            var tmp = queue[front];
            front++;

            return tmp;
        }
    }
}