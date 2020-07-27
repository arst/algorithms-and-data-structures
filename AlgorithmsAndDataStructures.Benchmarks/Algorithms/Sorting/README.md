``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.388 (2004/?/20H1)
AMD Ryzen 5 2600X, 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=3.1.200
  [Host]     : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT
  DefaultJob : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT


```
|               Method |         Mean |      Error |     StdDev |  Ratio | RatioSD |
|--------------------- |-------------:|-----------:|-----------:|-------:|--------:|
|           BubbleSort | 38,042.22 μs | 258.830 μs | 242.110 μs | 163.73 |    2.24 |
|             CombSort |    338.79 μs |   2.895 μs |   2.708 μs |   1.46 |    0.02 |
|            CountSort |     74.30 μs |   0.782 μs |   0.653 μs |   0.32 |    0.00 |
|             HeapSort |    189.56 μs |   1.929 μs |   1.804 μs |   0.82 |    0.01 |
|        InsertionSort | 12,198.79 μs |  57.873 μs |  51.303 μs |  52.55 |    0.53 |
|            MergeSort |    353.91 μs |   3.328 μs |   2.950 μs |   1.52 |    0.02 |
| PartitionedMergeSort |    485.27 μs |   2.857 μs |   2.672 μs |   2.09 |    0.03 |
|            QuickSort |    232.37 μs |   2.838 μs |   2.655 μs |   1.00 |    0.00 |
|            RadixSort |    770.88 μs |  15.257 μs |  38.276 μs |   3.14 |    0.15 |
|        SelectionSort | 26,314.51 μs | 341.604 μs | 302.823 μs | 113.37 |    2.25 |
|            ShellSort |    248.96 μs |   0.664 μs |   0.589 μs |   1.07 |    0.01 |
