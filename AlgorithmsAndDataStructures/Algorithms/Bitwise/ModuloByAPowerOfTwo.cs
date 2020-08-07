namespace AlgorithmsAndDataStructures.Algorithms.Bitwise
{
    public class ModuloByAPowerOfTwo
    {
#pragma warning disable CA1822 // Mark members as static
        public int Modulo(int number, int divider)
#pragma warning restore CA1822 // Mark members as static
        {
            return number & (divider - 1);
        }
    }
}
