using AlgorithmsAndDataStructures.Algorithms.Strings.LevenstineDistance;
using BenchmarkDotNet.Attributes;

namespace AlgorithmsAndDataStructures.Benchmarks.Algorithms.String.LevenstineDistance
{
    public class LevenstineDistanceBenchmark
    {
        private readonly LevenstineDistanceDynamicProgramming levenstineDistanceDynamicProgramming = new LevenstineDistanceDynamicProgramming();

        [Params(0, 1)]
        public int DataIndex { get; set; }

        private readonly (string, string)[] data =
        {
            ("ABC ABCDAB ABCDABCDABD", "ABCDABCD"), ("eF8Qz1KHBvwZz0xd6UpodWQ4UyRLXUJ8qZy1df1nZJId9bEYqM50niQGRfaHpSdS7GXgQYR5ckbK94NxHbTJjrPDNsk37JsrfIk4GwcCZmozudSFXCtUST2xIzuHsgwQKIiEmNQsbFmqayQ1YJQDAJtFgduqxJGykdlkQMHkABzOrVg9fD9J8zJHjWqPnbDC2cGqR7qoxML4geLu1OPv1DG7M9IOsSWri808LjnWmjajm3yfcpkQlSM8vR6t3mACMeB0hJYyPzT4JmxfODPNJD9IsuDvqXO", "bU9cPrVRnx9VlUGLXr3Fp5meCcTwC8HuGxJJ5abn1npMPzM0mXFwlVLjxBSnySmwcen16b7sXb0b3F1ScZXKgzgaUaASsQp2vksJjfCW7jTDLrMmXBDtwT24KrU7NYpxEMKg7LXfyM0XfOBGqDCVoOweyp3iY9jAuwvSXuEeuyPKwHx8QyoGF4Tmz4KKTUBsRnBBGM1kdZ8WqRPGwATqjOQ7lHwNvG7ae8T4xftAAnlS60Wu6I2z4oKXH2cvJ9hDzrRsxgc5nEv47xbf5hBXqnlywVwRirw")
        };

        [Benchmark]
        public void Benchmark() =>
            levenstineDistanceDynamicProgramming.GetLevenstineDistance(data[DataIndex].Item1, data[DataIndex].Item2);
    }
}
