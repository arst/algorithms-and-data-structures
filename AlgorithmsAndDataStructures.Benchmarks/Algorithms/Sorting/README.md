``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.388 (2004/?/20H1)
AMD Ryzen 5 2600X, 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=3.1.200
  [Host]     : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT
  DefaultJob : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT


```
|               Method |          Mean |      Error |       StdDev |        Median |  Ratio | RatioSD |
|--------------------- |--------------:|-----------:|-------------:|--------------:|-------:|--------:|
|           BubbleSort | 114,033.07 μs | 290.135 μs |   271.393 μs | 114,075.78 μs | 199.80 |    1.42 |
|             CombSort |     656.44 μs |   1.301 μs |     1.016 μs |     656.63 μs |   1.15 |    0.01 |
|            CountSort |      87.59 μs |   1.704 μs |     2.551 μs |      88.50 μs |   0.15 |    0.01 |
|             HeapSort |     749.66 μs |   7.885 μs |     7.375 μs |     749.49 μs |   1.31 |    0.01 |
|        InsertionSort |  14,938.49 μs |  20.476 μs |    19.153 μs |  14,933.73 μs |  26.17 |    0.16 |
|            MergeSort |   1,899.03 μs |  13.150 μs |    12.301 μs |   1,897.60 μs |   3.33 |    0.03 |
| PartitionedMergeSort |     884.83 μs |   3.343 μs |     2.791 μs |     883.54 μs |   1.55 |    0.01 |
|            QuickSort |     570.72 μs |   4.230 μs |     3.750 μs |     570.71 μs |   1.00 |    0.00 |
|            RadixSort |   1,017.54 μs |  38.925 μs |   114.772 μs |   1,060.05 μs |   1.84 |    0.17 |
|        SelectionSort |  26,544.81 μs | 526.512 μs | 1,039.283 μs |  26,083.23 μs |  48.52 |    2.15 |
|            ShellSort |     791.54 μs |   3.117 μs |     2.915 μs |     791.39 μs |   1.39 |    0.01 |
