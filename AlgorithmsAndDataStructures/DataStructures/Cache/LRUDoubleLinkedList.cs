using System;

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

        public void InsertToHead(LRUCacheEntry entry)
        {
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

        public LRUCacheEntry InsertToTail(LRUCacheEntry cacheEntry)
        {
            if (head == null)
            {
                head = cacheEntry;
                tail = head;
            }
            else
            {
                tail.Next = cacheEntry;
                cacheEntry.Previous = tail;
                tail = cacheEntry;
            }

            return cacheEntry;
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

        public bool IsEmpty()
        {
            return head == null;
        }

        internal void Remove(LRUCacheEntry cacheEntry)
        {
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
