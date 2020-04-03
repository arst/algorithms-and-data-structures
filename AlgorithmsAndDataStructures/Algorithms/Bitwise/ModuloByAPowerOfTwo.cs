namespace AlgorithmsAndDataStructures.Algorithms.Bitwise
{
    public class ModuloByAPowerOfTwo
    {
        public int Modulo(int number, int divider)
        {
            return number & (divider - 1);
        }
    }
}
