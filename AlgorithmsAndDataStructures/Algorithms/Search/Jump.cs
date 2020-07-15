﻿using System;

namespace AlgorithmsAndDataStructures.Algorithms.Search
{
    public class Jump<T> : ISearchAlgorithm<T> where T : IComparable<T>
    {
        public int Search(T[] target, T value)
        {
            var jumpStep = (int)Math.Sqrt(target.Length);
            var currentJump = jumpStep;

            while (currentJump < target.Length)
            {
                if (target[currentJump].CompareTo(value) == 0)
                {
                    return currentJump;
                }

                if (target[currentJump].CompareTo(value) > 0)
                {
                    // Search latest jumped interval with simple linear search.
                    for (int i = currentJump - jumpStep; i < currentJump; i++)
                    {
                        if (target[i].CompareTo(value) == 0)
                        {
                            return i;
                        }
                    }

                    return -1;
                }
                else
                {
                    currentJump += jumpStep;
                }
            }

            // Search latest jumped interval with simple linear search.
            for (int i = currentJump - jumpStep; i < target.Length; i++)
            {
                if (target[i].CompareTo(value) == 0)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
