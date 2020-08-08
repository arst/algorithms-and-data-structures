using System;

namespace AlgorithmsAndDataStructures.Algorithms.StringAlgorithms.LevenstineDistance
{
    public class LevenstineDistanceDynamicProgramming
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static",
            Justification = "To follow code style")]
        public int GetLevenstineDistance(string left, string right)
        {
            if (string.IsNullOrEmpty(right) || string.IsNullOrEmpty(left))
            {
                return default;
            }

            var distancesTable = new int[left.Length + 1][];
            
            for (var i = 0; i < left.Length + 1; i++)
            {
                distancesTable[i] = new int[right.Length + 1]; 
            }

            for (var i = 0; i < right.Length + 1; i++)
            {
                // To transform empty string to any substring of right input we need ar least i insertions
                distancesTable[0][i] = i;
            }

            for (var i = 0; i < left.Length + 1; i++)
            {
                // To transform empty string to any substring of left input we need ar least i insertions
                distancesTable[i][0] = i;
            }

            // i = 1 since we already pre-calculated distance from e,pty string to both left and right substrings
            for (var i = 1; i < left.Length + 1; i++)
            {
                ref var row = ref distancesTable[i];
                for (var j = 1; j < right.Length + 1; j++)
                {
                    ref var cell = ref row[j];
                    cell = Math.Min(
                        // Replace, note:
                        // we need to add one only if current characters are mismatched, i and j are shifted by one since we start out distance table
                        // with empty string and not with first characters
                        distancesTable[i - 1][j - 1] + (left[i - 1] != right[j - 1] ? 1 : 0), 
                        Math.Min(
                        // Insert
                        distancesTable[i - 1][j] + 1,
                        // Delete
                        row[j - 1] + 1));
                }
            }

            return distancesTable[left.Length][right.Length];
        }
    }
}
