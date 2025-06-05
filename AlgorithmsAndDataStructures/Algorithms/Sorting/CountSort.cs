using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.Sorting;

public class CountSort : ISortingAlgorithm
{
    public void Sort(int[] target)
    {
        if (target is null) return;

        var helper = new int[(target.Length > 0 ? target.Max() : 0) + 1];

        foreach (var element in target) helper[element]++;

        var targetIndex = 0;
        for (var i = 0; i < helper.Length; i++)
        {
            var count = helper[i];

            if (count <= 0) continue;

            var stopIndex = targetIndex + count;
            for (var j = targetIndex; j < stopIndex; j++)
            {
                target[targetIndex] = i;
                targetIndex++;
            }
        }
    }
}