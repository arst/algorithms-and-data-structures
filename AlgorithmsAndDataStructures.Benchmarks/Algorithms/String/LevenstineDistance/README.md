``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.388 (2004/?/20H1)
AMD Ryzen 5 2600X, 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=3.1.200
  [Host]     : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT
  DefaultJob : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT


```

| Method        | DataIndex |           Mean |         Error |        StdDev |
|---------------|-----------|---------------:|--------------:|--------------:|
| **Benchmark** | **0**     |   **2.337 μs** | **0.0466 μs** | **0.1204 μs** |
| **Benchmark** | **1**     | **419.780 μs** | **7.8059 μs** | **7.3017 μs** |
