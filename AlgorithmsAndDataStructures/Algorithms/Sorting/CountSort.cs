using System;
using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.Sorting
{
    public class CountSort : ISortingAlgorithm
    {
        public void Sort(int[] target)
        {
            if (!target.Any())
            {
                return;
            }

            var helper = new int[target.Max() + 1];

            for (int i = 0; i < target.Length; i++)
            {
                helper[target[i]]++;
            }

            var targetIndex = 0;
            for (var i = 0; i < helper.Length; i++)
            {
                var count = helper[i];

                if (count <= 0)
                {
                    continue;
                }

                var stopIndex = targetIndex + count;
                for (var j = targetIndex; j < stopIndex; j++)
                {
                    target[targetIndex] = i;
                    targetIndex++;
                }
            }
            
        }
    }
}
