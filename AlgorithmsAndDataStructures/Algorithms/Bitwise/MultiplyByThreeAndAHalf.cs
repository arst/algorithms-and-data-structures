namespace AlgorithmsAndDataStructures.Algorithms.Bitwise
{
    public class MultiplyByThreeAndAHalf
    {
        // What is 3.5 of the number? It is 2 * number + number + number / 2
        // We can achieve this with some bit shifts
#pragma warning disable CA1822 // Mark members as static
        public int Multiply(int input)
#pragma warning restore CA1822 // Mark members as static
        {
            return (input << 1) + input + (input >> 1);
        }
    }
}
