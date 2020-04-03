namespace AlgorithmsAndDataStructures.Algorithms.Bitwise
{
    public class MuttiplyByThreeAndAHalf
    {
        // What is 3.5 of the number? It is 2 * number + number + number / 2
        // We can achieve this with some bit shifts
        public int Multiply(int input)
        {
            return (input << 1) + input + (input >> 1);
        }
    }
}
