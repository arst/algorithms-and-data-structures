using AlgorithmsAndDataStructures.DataStructures.LinkedList;

namespace AlgorithmsAndDataStructures.Algorithms.Search
{
    public class SublistSearch
    {
        /*
         Time Complexity : O(m*n) 
         where m is the number of nodes in second list and n in first.
         */
#pragma warning disable CA1822 // Mark members as static
        public bool IsSubset(SinglyLinkedList<int> input, SinglyLinkedList<int> pattern)
#pragma warning restore CA1822 // Mark members as static
        {
            if (input is null || pattern is null)
            {
                return default;
            }

            var patternPointer = pattern.GetHead();
            var inputPointer = input.GetHead();

            while (inputPointer != null && patternPointer != null)
            {
                if (inputPointer.Value != patternPointer.Value)
                {
                    if (patternPointer != pattern.GetHead())
                    {
                        patternPointer = pattern.GetHead();
                    }
                    else
                    {
                        inputPointer = inputPointer.Next;
                    }
                }
                else
                {
                    patternPointer = patternPointer.Next;
                    inputPointer = inputPointer.Next;
                }
            }

            return patternPointer == null;
        }
    }
}
