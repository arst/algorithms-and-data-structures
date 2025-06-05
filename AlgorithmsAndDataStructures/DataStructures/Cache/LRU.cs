using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.DataStructures.Cache;

public class Lru
{
    private readonly int capacity;
    private readonly CacheDoubleLinkedList list;
    private readonly Dictionary<int, CacheEntry> values;
    private int entriesCount;

    public Lru(int capacity)
    {
        values = new Dictionary<int, CacheEntry>();
        this.capacity = capacity;
        entriesCount = 0;
        list = new CacheDoubleLinkedList();
    }

    public void Add(int key, string value)
    {
        if (values.ContainsKey(key)) values[key].UpdateValue(value);

        if (entriesCount == capacity)
        {
            var removedEntry = list.RemoveTail();
            values.Remove(removedEntry.Key);
            entriesCount--;
        }

        var newEntry = new CacheEntry(key, value);
        list.InsertToHead(newEntry);
        values.Add(key, newEntry);

        entriesCount++;
    }

    public string Get(int key)
    {
        if (!values.ContainsKey(key)) return null;

        var entry = values[key];

        if (entriesCount > 1) list.MoveToHead(entry);

        return entry.Value;
    }
}