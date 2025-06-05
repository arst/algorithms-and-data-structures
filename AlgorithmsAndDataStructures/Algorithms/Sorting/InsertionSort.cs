namespace AlgorithmsAndDataStructures.Algorithms.Sorting;

/* Characteristics:
 * Complexity: o(n^2)
 * Stable: YES
 * In-place: YES
 * Online: YES
 * Advantages:
 * 1. Simple implementation
 * 2. Efficient for (quite) small data sets, much like other quadratic sorting algorithms
 * 3. More efficient in practice than most other simple quadratic (i.e., O(n^2)) algorithms such as selection sort or bubble sort
 * 4. Adaptive, i.e., efficient for data sets that are already substantially sorted:
 *    the time complexity is O(kn) when each element in the input is no more than k places away from its sorted position
 */
public class InsertionSort : ISortingAlgorithm
{
    public void Sort(int[] target)
    {
        if (target is null) return;

        for (var i = 0; i < target.Length; i++)
        {
            var j = i;
            var temp = target[i];
            while (j > 0 && target[j - 1] > temp)
            {
                target[j] = target[j - 1];
                j--;
            }

            target[j] = temp;
        }
    }
}