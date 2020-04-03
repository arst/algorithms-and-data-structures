namespace AlgorithmsAndDataStructures.Algorithms.Bitwise
{
    public class AddOne
    {
        // Add one is simple to the numbers with the last bu set to 0, just flip it
        // for numbers that have 1 here it's more complex cause you need to carry this bit left until you find 0 bit
        // just like in 10-base arithmetic
        // Idea: find the rightmost 0 bit and flip it with zeroing out previous bits
        public int Add(int i)
        {
            // It's 0000...1 with last bit set to 1
            var flipper = 1;

            // Check for the latest uninspected bit if it's set
            // When we got 0 or less it means that we found the rightmost 0 bit
            while ((i & flipper) > 0)
            {
                // Remove the last bit
                i = i ^ flipper;
                // This would effectively multiply flipper by 2, so it would get 1,2,4,8 and so on
                flipper = flipper << 1;
            }
            // Flip the rightmost 0 bit
            return i ^ flipper;
        }
    }
}
