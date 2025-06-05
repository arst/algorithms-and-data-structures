using System;
using System.Collections.Generic;
using System.Linq;
using AlgorithmsAndDataStructures.Algorithms.Hashing;

namespace AlgorithmsAndDataStructures.DataStructures.CuckooFilter;

public class CuckooFilter
{
    private static readonly Random Random = new(500);
    private readonly List<List<int>> buckets;
    private readonly int bucketSize;
    private readonly int fingerprintSize;
    private readonly FowlerNollVo1ABasedHash hashGenerator;
    private readonly int maxInsertionAttempts;
    private readonly int seed;

    public CuckooFilter(int size, int bucketSize = 100, int seed = 255, int fingerprintSize = 16,
        int maxInsertionAttempts = 500)
    {
        this.bucketSize = bucketSize;
        this.maxInsertionAttempts = maxInsertionAttempts;
        this.seed = seed;
        this.fingerprintSize = fingerprintSize;
        buckets = new List<List<int>>(size);
        for (var i = 0; i < size; i++) buckets.Add(new List<int>(bucketSize));

        hashGenerator = new FowlerNollVo1ABasedHash();
    }

    public void Add(string element)
    {
        var (fingerPrint, firstBucket, secondBucket) = CalculateBucketPlacement(element);
        TryInsert(fingerPrint, firstBucket, secondBucket, maxInsertionAttempts);
    }

    private (int FingerPrint, int FirstBucket, int SecondBucket) CalculateBucketPlacement(string element)
    {
        var fingerPrint = CalculateFingerPrint(element);
        var (firstBucket, secondBucket) = CalculateBuckets(fingerPrint);
        return (fingerPrint, firstBucket, secondBucket);
    }

    private int CalculateFingerPrint(string element)
    {
        // Take first fingerprintSize bits of the hash
        return hashGenerator.GetHash(element, seed) & ((1 << fingerprintSize) - 1);
    }

    private (int FirstBucket, int SecondBucket) CalculateBuckets(int fingerPrint)
    {
        var firstBucket = Math.Abs(fingerPrint % buckets.Count);
        // XOR Makes second bucket calculation cheap and independent of the first bucket
        var secondBucket = Math.Abs((firstBucket ^ fingerPrint) % buckets.Count);
        return (firstBucket, secondBucket);
    }

    private void TryInsert(int fingerPrint, int firstBucket, int secondBucket, int insertAttemptsLeft)
    {
        while (true)
        {
            if (insertAttemptsLeft == 0)
                throw new InvalidOperationException(
                    "Failed to insert element. Filter is Full. No dynamic expansion is implemented yet.");

            if (buckets[firstBucket].Count < bucketSize)
            {
                buckets[firstBucket].Add(fingerPrint);
                return;
            }

            if (buckets[secondBucket].Count < bucketSize)
            {
                buckets[secondBucket].Add(fingerPrint);
                return;
            }

            var choose = Random.Next(2);
            var bucketToEvict = choose == 0 ? firstBucket : secondBucket;
            var evictionVictim = Random.Next(buckets[bucketToEvict].Count);
            var evictedFingerPrint = buckets[bucketToEvict].ElementAt(evictionVictim);
            var (newFirstBucket, newSecondBucket) = CalculateBuckets(evictedFingerPrint);

            fingerPrint = evictedFingerPrint;
            firstBucket = newFirstBucket;
            secondBucket = newSecondBucket;
            insertAttemptsLeft -= 1;
        }
    }

    public bool Contains(string element)
    {
        var fingerPrint = CalculateFingerPrint(element);
        var (firstBucket, secondBucket) = CalculateBuckets(fingerPrint);

        return buckets[firstBucket].Contains(fingerPrint) || buckets[secondBucket].Contains(fingerPrint);
    }

    public void Remove(string element)
    {
        var fingerPrint = CalculateFingerPrint(element);
        var (firstBucket, secondBucket) = CalculateBuckets(fingerPrint);

        if (buckets[firstBucket].Contains(fingerPrint)) buckets[firstBucket].Remove(fingerPrint);

        if (buckets[secondBucket].Contains(fingerPrint)) buckets[secondBucket].Remove(fingerPrint);
    }
}