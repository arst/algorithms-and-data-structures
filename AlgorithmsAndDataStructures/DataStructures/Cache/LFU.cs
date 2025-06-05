using System.Collections.Generic;

namespace AlgorithmsAndDataStructures.DataStructures.Cache;

public class Lfu
{
    private const int DefaultFrequency = 1;
    private readonly int capacity;
    private readonly Dictionary<int, CacheDoubleLinkedList> frequencies;
    private readonly Dictionary<CacheEntry, int> nodeFrequencies;
    private readonly Dictionary<int, CacheEntry> values;
    private int entriesCount;
    private int minFrequency;

    public Lfu(int capacity)
    {
        values = new Dictionary<int, CacheEntry>();
        frequencies = new Dictionary<int, CacheDoubleLinkedList>();
        nodeFrequencies = new Dictionary<CacheEntry, int>();
        minFrequency = int.MaxValue;
        this.capacity = capacity;
        entriesCount = 0;
    }

    public void Add(int key, string value)
    {
        if (values.ContainsKey(key))
        {
            values[key].UpdateValue(value);
            PromoteEntry(values[key]);
            return;
        }

        if (entriesCount == capacity)
        {
            var evictedEntry = frequencies[minFrequency].RemoveTail();
            values.Remove(evictedEntry.Key);

            if (frequencies[minFrequency].IsEmpty) frequencies.Remove(minFrequency);

            entriesCount--;
        }

        if (!frequencies.ContainsKey(DefaultFrequency)) frequencies[DefaultFrequency] = new CacheDoubleLinkedList();

        var newEntry = new CacheEntry(key, value);
        frequencies[DefaultFrequency].InsertToHead(newEntry);
        values[key] = newEntry;
        nodeFrequencies[newEntry] = DefaultFrequency;
        minFrequency = DefaultFrequency;
        entriesCount++;
    }

    public string Get(int key)
    {
        if (!values.ContainsKey(key)) return null;

        var entry = values[key];

        PromoteEntry(entry);

        return entry.Value;
    }

    private void PromoteEntry(CacheEntry cacheEntry)
    {
        var currentFrequency = nodeFrequencies[cacheEntry];
        frequencies[currentFrequency].Remove(cacheEntry);

        if (frequencies[currentFrequency].IsEmpty) frequencies.Remove(currentFrequency);

        var newFrequency = ++currentFrequency;

        if (!frequencies.ContainsKey(newFrequency)) frequencies[newFrequency] = new CacheDoubleLinkedList();

        frequencies[newFrequency].InsertToHead(cacheEntry);
        nodeFrequencies[cacheEntry] = newFrequency;
    }
}