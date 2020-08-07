namespace AlgorithmsAndDataStructures.Algorithms.Bitwise
{
    public class IsPowerOfFour
    {
        //0xAAAAAAAA is 10101010101010101010101010101010 in binary which covers all powers that are not powers of 4
        private const uint NonOddPowers = 0xAAAAAAAA;

        //Though the simplest way would be to rake 4 based log and check for the reminder Math.Log(i, 4) % 1 == 0
#pragma warning disable CA1822 // Mark members as static
        public bool IsPower(int number)
#pragma warning restore CA1822 // Mark members as static
        {
            var isNonZero = number != 0;
            var isEven = (number & (number - 1)) == 0;

            // we can check that all bits for non-4 powers aren't set
            return isNonZero && isEven && (number & NonOddPowers) == 0;
        }
    }
}
