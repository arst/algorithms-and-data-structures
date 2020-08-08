using System;

namespace AlgorithmsAndDataStructures.DataStructures.SelfOrganizingList
{
    public class CountBasedSelfOrganizingList<T>
    {
        public CountBaseSelfOganizedListNode<T> Head { get; private set; }

        private CountBaseSelfOganizedListNode<T> tail;

        public void Add(T value)
        {
            if (Head == null)
            {
                Head = new CountBaseSelfOganizedListNode<T> { Value = value };
                tail = Head;
                return;
            }

            tail.Next = new CountBaseSelfOganizedListNode<T> { Value = value };
            tail = tail.Next;
        }

        public CountBaseSelfOganizedListNode<T> Get(T value)
        {
            if (Head == null)
            {
                return null;
            }

            if (Head.Value.Equals(value))
            {
                Head.Count = Head.Count + 1;

                return Head;
            }

            var current = Head.Next;
            var previous = Head;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {
                    previous.Next = current.Next;
                    current.Next = Head;
                    Head = current;
                    Head.Count = Head.Count + 1;
                    Sink();
                    return current;
                }
                previous = current;
                current = current.Next;
            }

            return null;
        }

        private void Sink()
        {
            if (Head.Next == null)
            {
                return;
            }

            if (Head.Count < Head.Next.Count)
            {
                var next = Head.Next;
                Head.Next = next.Next;
                next.Next = Head;
                Head = next;
            }

            var current = Head.Next;
            var previous = Head;

            while (current != null && current.Next != null)
            {
                if (current.Count < current.Next.Count)
                {
                    Swap(previous, current, current.Next);
                }
                current = current.Next;
            }
        }

        private void Swap(CountBaseSelfOganizedListNode<T> previous, CountBaseSelfOganizedListNode<T> current, CountBaseSelfOganizedListNode<T> next)
        {
            if (next == null)
            {
                return;
            }

            previous.Next = next;
            current.Next = next.Next;
            next.Next = current;
        }
    }
}
