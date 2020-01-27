using System.Linq;

namespace AlgorithmsAndDataStructures.Algorithms.Sorting
{
    public class RadixSort : ISortingAlgorithm
    {
        public void Sort(int[] target)
        {
            if (!target.Any())
            {
                return;
            }

            var max = target.Max();

            for (int exp = 1; max / exp > 0; exp *= 10)
            {
                StableCountingSort(target, exp);
            }
        }

        private void StableCountingSort(int[] target, int exp)
        {
            var max = target.Max();
            var counters = new int[10];
            var holder = new int[target.Length];

            for (int i = 0; i < target.Length; i++)
            {
                counters[(target[i] / exp) % 10]++;
            }

            for (int i = 1; i < counters.Length; i++)
            {
                counters[i] = counters[i] + counters[i - 1];
            }

            for (int i = target.Length - 1; i > -1; i--)
            {
                counters[(target[i] / exp) % 10]--;
                holder[counters[(target[i] / exp) % 10]] = target[i];
            }

            for (int i = 0; i < target.Length; i++)
            {
                target[i] = holder[i];
            }
        }
    }
}
