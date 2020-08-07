namespace AlgorithmsAndDataStructures.Algorithms.DynamicProgramming
{
    public interface IZeroOneKnapsack
    {
        int GetMaxGain(int[] weights, int[] values, int knapsackSize);
    }
}