namespace AlgorithmsAndDataStructures.Algorithms.Bitwise
{
    public class TurnOffRightMostBit
    {
        public int TurnOff(int number)
        {
            return number & (number - 1);
        }
    }
}
