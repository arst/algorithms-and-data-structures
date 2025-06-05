using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AlgorithmsAndDataStructures.Algorithms.Hashing;

namespace AlgorithmsAndDataStructures.DataStructures.BloomFilter;

public class BloomFilter
{
    private readonly BitArray filter;
    private readonly FowlerNollVo1ABasedHash hashGenerator;
    private readonly List<int> seeds;

    public BloomFilter(int size, int numberOfHashesPerEntry)
    {
        filter = new BitArray(size);
        seeds = [];
        hashGenerator = new FowlerNollVo1ABasedHash();

        for (var i = 0; i < numberOfHashesPerEntry; i++) seeds.Add(Random.Shared.Next());
    }

    public void Add(string s)
    {
        foreach (var hash in seeds.Select(seed => hashGenerator.GetHash(s, seed)))
            filter[(hash % filter.Length + filter.Length) % filter.Length] = true;
    }

    public bool Contains(string s)
    {
        return seeds.Select(seed => hashGenerator.GetHash(s, seed))
            .All(hash => filter[(hash % filter.Length + filter.Length) % filter.Length]);
    }
}