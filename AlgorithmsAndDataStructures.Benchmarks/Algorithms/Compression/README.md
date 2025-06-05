``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18362.959 (1903/May2019Update/19H1)
Intel Core i7-8750H CPU 2.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=3.1.201
  [Host]     : .NET Core 3.1.3 (CoreCLR 4.700.20.11803, CoreFX 4.700.20.12001), X64 RyuJIT
  DefaultJob : .NET Core 3.1.3 (CoreCLR 4.700.20.11803, CoreFX 4.700.20.12001), X64 RyuJIT


```

| Method                 |     Mean |     Error |    StdDev |   Median | Ratio | RatioSD |
|------------------------|---------:|----------:|----------:|---------:|------:|--------:|
| HuffmanCodeCompression | 4.162 ms | 0.4474 ms | 1.3193 ms | 3.509 ms |  1.00 |    0.00 |
| LZWCompression         | 3.576 ms | 0.0699 ms | 0.1002 ms | 3.561 ms |  0.81 |    0.30 |
