using System;

namespace AlgorithmsAndDataStructures.Algorithms.String.LevenstineDistance
{
    public class LevenstineDistanceDynamicProgramming
    {
        public int GetLevenstineDistance(string left, string right)
        {
            var distancesTable = new int[left.Length + 1][];
            
            for (int i = 0; i < left.Length + 1; i++)
            {
                distancesTable[i] = new int[right.Length + 1]; 
            }

            for (int i = 0; i < right.Length + 1; i++)
            {
                // To transform empty string to any substring of right input we need ar least i insertions
                distancesTable[0][i] = i;
            }

            for (int i = 0; i < left.Length + 1; i++)
            {
                // To transform empty string to any substring of left input we need ar least i insertions
                distancesTable[i][0] = i;
            }

            // i = 1 since we already precalculated distance from e,pty string to both left and right substrings
            for (int i = 1; i < left.Length + 1; i++)
            {
                for (int j = 1; j < right.Length + 1; j++)
                {
                    distancesTable[i][j] = Math.Min(
                        // Replace, note: we need to add one only if current characters are mismatched, i and j are shifted by one since we start out distance table
                        // with empty string and not with first characters
                        distancesTable[i - 1][j - 1] + (left[i - 1] != right[j - 1] ? 1 : 0), 
                        Math.Min(
                        // Insert
                        distancesTable[i - 1][j] + 1,
                        // Delete
                        distancesTable[i][j - 1] + 1));
                }
            }

            return distancesTable[left.Length][right.Length];
        }
    }
}
