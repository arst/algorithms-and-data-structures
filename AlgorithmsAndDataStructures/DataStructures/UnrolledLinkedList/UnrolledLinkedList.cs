using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.DataStructures.UnrolledLinkedList
{
    public class UnrolledLinkedList<T>
    {
        private UnrolledLinkedListNode<T> head;
        private UnrolledLinkedListNode<T> tail;

        public void Add(T value)
        {
            if (head == null)
            {
                head = new UnrolledLinkedListNode<T>();
                head.Values[0] = value;
                head.CurrentIndex = head.CurrentIndex + 1;
                tail = head;
            }
            else
            {
                if (tail.CurrentIndex == 5)
                {
                    tail.Next = new UnrolledLinkedListNode<T>();
                    tail.Next.Values[0] = value;
                    tail.Next.CurrentIndex = tail.Next.CurrentIndex + 1;
                    tail = tail.Next;
                }
                else
                {
                    tail.Values[tail.CurrentIndex] = value;
                    tail.CurrentIndex = tail.CurrentIndex + 1;
                }
            }
        }

        public UnrolledLinkedListNode<T> Find(T value)
        {
            var current = head;

            while (current != null)
            {
                for (int i = 0; i < current.CurrentIndex; i++)
                {
                    if (current.Values[i].Equals(value))
                    {
                        return current;
                    }
                }

                current = current.Next;
            }

            return null;
        }

        public List<T> Unroll()
        {
            var current = head;
            var result = new List<T>();

            while (current != null)
            {
                for (int i = 0; i < current.CurrentIndex; i++)
                {
                    result.Add(current.Values[i]);
                }

                current = current.Next;
            }

            return result;
        }
    }
}
