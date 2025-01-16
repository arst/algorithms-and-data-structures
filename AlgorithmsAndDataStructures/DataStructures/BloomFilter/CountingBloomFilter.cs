using System;
using System.Collections.Generic;
using System.Linq;
using AlgorithmsAndDataStructures.Algorithms.Hashing;

namespace AlgorithmsAndDataStructures.DataStructures.BloomFilter;

public class CountingBloomFilter
{
    private readonly List<int> filter;
    private readonly List<int> seeds;
    private readonly FowlerNollVo1ABasedHash hashGenerator;

    public CountingBloomFilter(int size, int numberOfHashesPerEntry)
    {
        filter = Enumerable.Repeat(0, size).ToList();
        seeds = [];
        hashGenerator = new FowlerNollVo1ABasedHash();
        
        for (var i = 0; i < numberOfHashesPerEntry; i++)
        {
            seeds.Add(Random.Shared.Next());
        }
    }

    public void Add(string s)
    {
        foreach (var hash in seeds.Select(seed => hashGenerator.GetHash(s, seed)))
        {
            filter[hash % filter.Count] += 1;
        }
    }
    
    public void Remove(string s)
    {
        foreach (var hash in seeds.Select(seed => hashGenerator.GetHash(s, seed)))
        {
            filter[(hash % filter.Count + filter.Count) % filter.Count] -= 1;
        }
    }
    
    public bool Contains(string s)
    {
        return seeds.Select(seed => hashGenerator.GetHash(s, seed)).All(hash => filter[(hash % filter.Count + filter.Count) % filter.Count] > 0);
    }
}