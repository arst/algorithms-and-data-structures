namespace AlgorithmsAndDataStructures.Algorithms.Utils
{
    internal static class ArrayUtils
    {
        internal static T[][] InitializeMultiDimensionalArray<T>(int height, int width)
        {
            var result = new T[height][];

            for (var i = 0; i < result.Length; i++)
            {
                result[i] = new T[width];
            }

            return result;
        }
    }
}
