``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19043
Intel Core i7-8750H CPU 2.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=3.1.201
  [Host]     : .NET Core 3.1.3 (CoreCLR 4.700.20.11803, CoreFX 4.700.20.12001), X64 RyuJIT
  DefaultJob : .NET Core 3.1.3 (CoreCLR 4.700.20.11803, CoreFX 4.700.20.12001), X64 RyuJIT


```
|               Method |          Mean |        Error |       StdDev |        Median |  Ratio | RatioSD |
|--------------------- |--------------:|-------------:|-------------:|--------------:|-------:|--------:|
|           BubbleSort | 117,587.04 μs | 1,439.053 μs | 1,346.091 μs | 117,056.36 μs | 194.05 |    3.25 |
|             CombSort |     934.56 μs |    12.142 μs |    19.949 μs |     924.64 μs |   1.55 |    0.05 |
|            CountSort |      99.74 μs |     1.929 μs |     1.981 μs |      99.60 μs |   0.17 |    0.00 |
|             HeapSort |   1,079.18 μs |    20.652 μs |    17.245 μs |   1,070.60 μs |   1.78 |    0.03 |
|        InsertionSort |  17,192.19 μs |   342.237 μs |   625.800 μs |  17,020.45 μs |  28.78 |    1.38 |
|            MergeSort |   2,133.73 μs |    41.959 μs |    64.076 μs |   2,125.44 μs |   3.53 |    0.12 |
| PartitionedMergeSort |   1,659.24 μs |    28.987 μs |    25.697 μs |   1,664.99 μs |   2.74 |    0.05 |
|            QuickSort |     605.86 μs |     5.565 μs |     4.647 μs |     606.14 μs |   1.00 |    0.00 |
|      QuickSortLomuto |     551.78 μs |     2.476 μs |     2.068 μs |     552.15 μs |   0.91 |    0.01 |
|            RadixSort |   1,026.63 μs |    14.031 μs |    11.717 μs |   1,026.56 μs |   1.69 |    0.02 |
|        SelectionSort |  54,854.87 μs |   766.600 μs |   717.078 μs |  54,996.57 μs |  90.50 |    1.43 |
|            ShellSort |     820.07 μs |     9.410 μs |     8.341 μs |     816.48 μs |   1.35 |    0.02 |
