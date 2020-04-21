namespace AlgorithmsAndDataStructures.DataStructures.Cache
{
    public class LRUDoubleLinkedList
    {
        private LRUCacheEntry head;
        private LRUCacheEntry tail;

        public LRUCacheEntry InsertToHead(int key, string value)
        {
            var result = new LRUCacheEntry(key, value);

            if (head == null)
            {
                head = result;
                tail = head;
            }
            else
            {
                result.Next = head;
                head.Previous = result;
                head = result;
            }

            return result;
        }

        public LRUCacheEntry RemoveTail()
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

        public void MoveToHead(LRUCacheEntry entry)
        {
            entry.Previous.Next = entry.Next;
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
    }
}
