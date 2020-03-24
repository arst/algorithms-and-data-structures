namespace AlgorithmsAndDataStructures.Algorithms.String.Sorting
{
    public class LSD
    {
        public string[] Sort(string[] input, int entryLength)
        {
            var alphabetSize = 256;
            var auxilary = new string[input.Length];

            for (int i = entryLength - 1; i >= 0; i--)
            {
                var counter = new int[alphabetSize + 1];

                for (int j = 0; j < input.Length; j++)
                {
                    var currentCharacter = input[j][i];
                    counter[currentCharacter + 1]++;
                }

                for (int j = 1; j < counter.Length; j++)
                {
                    counter[j] += counter[j - 1];
                }

                for (int j = 0; j < input.Length; j++)
                {
                    var currentCharacter = input[j][i];
                    auxilary[counter[currentCharacter]++] = input[j];
                }

                for (int j = 0; j < input.Length; j++)
                {
                    input[j] = auxilary[j];
                }
            }

            return input;
        }
    }
}
