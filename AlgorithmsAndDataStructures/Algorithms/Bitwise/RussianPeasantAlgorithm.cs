namespace AlgorithmsAndDataStructures.Algorithms.Bitwise
{
    public class RussianPeasantAlgorithm
    {
        public int Multiply(int x, int y)
        {
            int result = 0;

            // While second number doesn't become 1 
            while (y > 0)
            {

                // If second number becomes odd, 
                // add the first number to result 
                if ((y & 1) != 0)
                    result = result + x;

                // Double the first number 
                x = x << 1;
                // Half the second number
                y = y >> 1;
            }

            return result;
        }
    }
}
