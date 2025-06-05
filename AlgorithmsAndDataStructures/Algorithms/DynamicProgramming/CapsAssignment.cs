using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.DynamicProgramming;

public class CapsAssignment
{
    private int allCapsAssignedMask;
    private int collectionSize;
    private int[][] dp;
    private int[][] eachPersonCollections;

    public int GetMaxAssignment(int[][] capCollections, int hatCollectionSize)
    {
        if (capCollections is null || capCollections.Length == 0) return default;

        collectionSize = hatCollectionSize;
        eachPersonCollections = capCollections;
        allCapsAssignedMask = (1 << eachPersonCollections.Length) - 1;

        dp = new int[1 << capCollections.Length][];

        for (var i = 0; i < dp.Length; i++)
        {
            dp[i] = new int[collectionSize];

            for (var j = 0; j < dp[i].Length; j++) dp[i][j] = -1;
        }

        return GetMaxAssignmentInternal(0, 1);
    }

    private int GetMaxAssignmentInternal(int currentAssignment, int currentHat)
    {
        // Each person has a hat assigned.
        if (allCapsAssignedMask == currentAssignment) return 1;

        // All hats were inspected but not everyone has a cap assigned.
        if (currentHat >= collectionSize) return 0;

        // We already calculated this path, so we return cached result.
        if (dp[currentAssignment][currentHat] > -1) return dp[currentAssignment][currentHat];

        // Do not use current hat.
        var maxAssignmentsWithoutCurrentHat = GetMaxAssignmentInternal(currentAssignment, currentHat + 1);

        // Try to assign current hat.
        var personsCount = eachPersonCollections.Length;
        for (var currentPerson = 0; currentPerson < personsCount; currentPerson++)
        {
            var isPersonAlreadyHasHatAssigned = ((1 << currentPerson) & currentAssignment) != 0;

            // This person doesn't posses this hat.
            if (!eachPersonCollections[currentPerson].Contains(currentHat) || isPersonAlreadyHasHatAssigned) continue;

            maxAssignmentsWithoutCurrentHat +=
                GetMaxAssignmentInternal(currentAssignment | (1 << currentPerson), currentHat + 1);
        }

        dp[currentAssignment][currentHat] = maxAssignmentsWithoutCurrentHat;

        return dp[currentAssignment][currentHat];
    }
}