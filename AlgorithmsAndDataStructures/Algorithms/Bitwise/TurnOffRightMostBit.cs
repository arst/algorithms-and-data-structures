namespace AlgorithmsAndDataStructures.Algorithms.Bitwise
{
    public class TurnOffRightMostBit
    {
#pragma warning disable CA1822 // Mark members as static
        public int TurnOff(int number)
#pragma warning restore CA1822 // Mark members as static
        {
            return number & (number - 1);
        }
    }
}
