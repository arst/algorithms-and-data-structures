namespace AlgorithmsAndDataStructures.Algorithms.Bitwise
{
    public class TwoNumbersOppositeSign
    {
        public bool IsOppositeSign(int x, int y)
        {
            // The sign of an integer is the left most bit, since negative number is 2d compliment of a positive number
            // we can XOR two numbers and if the sign is different it would get 1 in the left most bit 
            // effetively rendering the result to be hegative number, if both numbers are positiove or negative we would get 0 in the leftmost bit
            return (x ^ y) < 0;
        }
    }
}
