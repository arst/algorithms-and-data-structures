namespace AlgorithmsAndDataStructures.DataStructures.SelfOrganizingList
{
    public class MoveToForwardSelfOrganizingList<T>
    {
        private SelfOrganizingListNode<T> tail;

        public SelfOrganizingListNode<T> Head { get; private set; }

        public void Add(T value)
        {
            if (Head == null)
            {
                Head = new SelfOrganizingListNode<T> { Value = value };
                tail = Head;
                return;
            }

            tail.Next = new SelfOrganizingListNode<T> { Value = value };
            tail = tail.Next;
        }

        public SelfOrganizingListNode<T> Get(T value)
        {
            if (Head == null)
            {
                return null;
            }

            if (Head.Value.Equals(value))
            {
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

                    return current;
                }
                previous = current;
                current = current.Next;
            }

            return null;
        }
    }
}
