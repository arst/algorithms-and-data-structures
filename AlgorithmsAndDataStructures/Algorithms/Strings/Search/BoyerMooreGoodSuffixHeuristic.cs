namespace AlgorithmsAndDataStructures.Algorithms.Strings.Search
{
    public class BoyerMooreGoodSuffixHeuristic : IStringPatternSearchAlgorithm
    {
        public int Search(string input, string pattern)
        {
            if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(pattern))
            {
                return -1;
            }

            var goodSuffixHeuristic = BuildGodSuffixHeuristic(pattern);
            PostProcessGodSuffixHeuristic(pattern, goodSuffixHeuristic);
            

            var patternIndex = pattern.Length - 1;
            var inputIndex = pattern.Length - 1;

            while (inputIndex < input.Length)
            {
                var isMatch = input[inputIndex] == pattern[patternIndex];
                if (isMatch)
                {
                    inputIndex--;
                    patternIndex--;
                }

                if (patternIndex < 0)
                {
                    return inputIndex + 1;
                }

                if (inputIndex > 0 && !isMatch)
                {
                    if (patternIndex == pattern.Length - 1)
                    {
                        inputIndex++;
                    }
                    else
                    {
                        patternIndex = pattern.Length - 1;
                        inputIndex += goodSuffixHeuristic.shifts[patternIndex + 1];
                            
                    }
                }
            }

            return -1;
        }

        private static void PostProcessGodSuffixHeuristic(string pattern, (int[] borders, int[] shifts) goodSuffixHeuristic)
        {
            int i, j;
            // The whole string longest border
            j = goodSuffixHeuristic.borders[0];
            for (i = 0; i <= pattern.Length; i++)
            {
                // If no shift, then shift to the border of the first character in the pattern
                if (goodSuffixHeuristic.shifts[i] == 0)
                    goodSuffixHeuristic.shifts[i] = j;
                // Current suffix became shorter then longest border, change j to the next longest border
                if (i == j)
                    j = goodSuffixHeuristic.borders[j];
            }
        }

        private static (int[] borders, int[] shifts) BuildGodSuffixHeuristic(string pattern)
        {
            // A border is a substring which is both proper suffix and proper prefix. 
            // F.E., in string “ccacc”, “c” is a border, “cc” is a border because it appears in both end of string but “cca” is not a border.
            var borders = new int[pattern.Length + 1];
            var shifts = new int[pattern.Length + 1];
            //Start with the empty string suffix
            var suffixStart = pattern.Length;
            var borderStarts = pattern.Length + 1;
            borders[suffixStart] = borderStarts;

            while (suffixStart > 0)
            {
                //if suffix can't be expanded to the left, we need to try to find smaller border
                while (borderStarts <= pattern.Length && pattern[suffixStart - 1] != pattern[borderStarts - 1])
                {
                    // To prevent override shifts for suffixes with the same borders:
                    // F.E., “addbddcdd”
                    if (shifts[borderStarts] == 0)
                    {
                        shifts[borderStarts] = borderStarts - 1;
                    }

                    borderStarts = borders[borderStarts];
                }

                suffixStart--;
                borderStarts--;
                borders[suffixStart] = borderStarts;
            }

            return (borders, shifts);            
        }
    }
}
