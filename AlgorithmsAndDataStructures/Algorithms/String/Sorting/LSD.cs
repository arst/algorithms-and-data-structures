namespace AlgorithmsAndDataStructures.Algorithms.String.Sorting
{
    public class Lsd
    {
#pragma warning disable CA1822 // Mark members as static
        public string[] Sort(string[] input, int entryLength)
#pragma warning restore CA1822 // Mark members as static
        {
            if (input is null)
            {
                return default;
            }

            const int alphabetSize = 256;
            var auxiliary = new string[input.Length];

            for (var i = entryLength - 1; i >= 0; i--)
            {
                var counter = new int[alphabetSize + 1];

                for (var j = 0; j < input.Length; j++)
                {
                    var currentCharacter = input[j][i];
                    counter[currentCharacter + 1]++;
                }

                for (var j = 1; j < counter.Length; j++)
                {
                    counter[j] += counter[j - 1];
                }

                for (var j = 0; j < input.Length; j++)
                {
                    var currentCharacter = input[j][i];
                    auxiliary[counter[currentCharacter]++] = input[j];
                }

                for (var j = 0; j < input.Length; j++)
                {
                    input[j] = auxiliary[j];
                }
            }

            return input;
        }
    }
}
