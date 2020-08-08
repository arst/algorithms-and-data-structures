namespace AlgorithmsAndDataStructures.DataStructures.Cache
{
    public class CacheDoubleLinkedList
    {
        private CacheEntry head;
        private CacheEntry tail;

        public bool IsEmpty => head == null;

        public void InsertToHead(CacheEntry entry)
        {
            if (entry is null)
            {
                return;
            }

            if (head == null)
            {
                head = entry;
                tail = head;
            }
            else
            {
                entry.Next = head;
                head.Previous = entry;
                head = entry;
            }
        }

        public CacheEntry RemoveTail()
        {
            var tmp = tail;

            if (tail.Previous != null)
            {
                tail.Previous.Next = null;
                tail = tail.Previous;
            }
            else
            {
                tail = null;
                head = null;
            }

            return tmp;
        }

        public void MoveToHead(CacheEntry entry)
        {
            if (entry is null)
            {
                return;
            }

            if (entry.Previous != null)
            {
                entry.Previous.Next = entry.Next;
            }

            if (entry.Next != null)
            {
                entry.Next.Previous = entry.Previous;
            }
            else
            {
                tail = entry.Previous;
            }

            entry.Previous = null;
            entry.Next = head;
            head.Previous = entry;
            head = entry;
        }


        public void Remove(CacheEntry cacheEntry)
        {
            if (cacheEntry is null)
            {
                return;
            }

            if (cacheEntry.Previous != null)
            {
                cacheEntry.Previous.Next = cacheEntry.Next;
            }

            if (cacheEntry.Next != null)
            {
                cacheEntry.Next.Previous = cacheEntry.Previous;
            }

            if (cacheEntry == head)
            {
                head = null;
            }

            cacheEntry.Next = null;
            cacheEntry.Previous = null;
        }
    }
}
