using System;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.DynamicProgramming
{
    public class CapsAssignment
    {
        private int hatCollectionSize;
        private int[][] caps;
        private int allCapsAssignedMask;
        private int[][] dp;

        public int GetMaxAssignment(int[][] caps, int hatCollectionMaxSize)
        {
            this.hatCollectionSize = hatCollectionMaxSize;
            this.caps = caps;
            allCapsAssignedMask = (1 << caps.Length) - 1;
            dp = new int[1 << caps.Length][];

            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[hatCollectionSize];

                for (int j = 0; j < dp[i].Length; j++)
                {
                    dp[i][j] = -1;
                }
            }

            return GetMaxAssignmentInternal(0, 1);
        }

        private int GetMaxAssignmentInternal(int currentAssignment, int currentHat)
        {
            // All caps assigned
            if (allCapsAssignedMask == currentAssignment)
            {
                return 1;
            }

            // All caps inspected but nor all person were assigned a hat
            if (currentHat >= hatCollectionSize)
            {
                return 0;
            }

            // We already calculated this path
            if (dp[currentAssignment][currentHat] > -1)
            {
                return dp[currentAssignment][currentHat];
            }

            // Do not use current hat
            var maxAssignmentsWithoutCurrentHat = GetMaxAssignmentInternal(currentAssignment, currentHat + 1);

            // Try assign current hat
            for (int j = 0; j < caps.Length; j++)
            {
                bool isPersonAlreadyHasHatAssigned = ((1 << j) & currentAssignment) != 0;

                // This person doesn't posses this hat
                if (!caps[j].Contains(currentHat) || isPersonAlreadyHasHatAssigned)
                {
                    continue;
                }

                maxAssignmentsWithoutCurrentHat += GetMaxAssignmentInternal(currentAssignment | (1 << j), currentHat + 1);
            }

            dp[currentAssignment][currentHat] = maxAssignmentsWithoutCurrentHat;

            return dp[currentAssignment][currentHat];
        }
    }
}
