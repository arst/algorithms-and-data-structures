namespace AlgorithmsAndDataStructures.DataStructures.SelfOrganizingList
{
    public class TransposeSelfOrginizingList<T>
    {
        private SelfOrganizingListNode<T> tail;

        public SelfOrganizingListNode<T> Head { get; private set; }

        public void Add(T value)
        {
            if (Head == null)
            {
                Head = new SelfOrganizingListNode<T>() { Value = value };
                tail = Head;
                return;
            }

            tail.Next = new SelfOrganizingListNode<T>() { Value = value };
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

            if (Head.Next == null)
            {
                return null;
            }

            if (Head.Next.Value.Equals(value))
            {
                var tmp = Head.Next;
                Head.Next = tmp.Next;
                tmp.Next = Head;
                Head = tmp;

                return tmp;
            }

            var current = Head.Next.Next;
            var prePrevious = Head;
            var previous = Head.Next;

            while (current != null)
            {
                if (current.Value.Equals(value))
                {

                    Swap(prePrevious, previous, current);
                    return current;
                }
                prePrevious = previous;
                previous = previous.Next;
                current = previous.Next;
            }

            return null;
        }

        private void Swap(SelfOrganizingListNode<T> prePrevious, SelfOrganizingListNode<T> previous, SelfOrganizingListNode<T> current)
        {
            prePrevious.Next = current;
            previous.Next = current.Next;
            current.Next = previous;
        }
    }
}
