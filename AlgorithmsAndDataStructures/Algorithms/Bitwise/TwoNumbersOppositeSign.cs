namespace AlgorithmsAndDataStructures.Algorithms.Bitwise
{
    public class TwoNumbersOppositeSign
    {
#pragma warning disable CA1822 // Mark members as static
        public bool IsOppositeSign(int x, int y)
#pragma warning restore CA1822 // Mark members as static
        {
            // The sign of an integer is the left most bit, since negative number is 2d compliment of a positive number
            // we can XOR two numbers and if the sign is different it would get 1 in the left most bit 
            // effectively rendering the result to be negative number, if both numbers are positive or negative we would get 0 in the leftmost bit
            return (x ^ y) < 0;
        }
    }
}
