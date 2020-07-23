``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.388 (2004/?/20H1)
AMD Ryzen 5 2600X, 1 CPU, 12 logical and 6 physical cores
.NET Core SDK=3.1.200
  [Host]     : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT
  DefaultJob : .NET Core 3.1.2 (CoreCLR 4.700.20.6602, CoreFX 4.700.20.6702), X64 RyuJIT


```
|                                  Method |     Mean |     Error |    StdDev | Ratio | RatioSD |
|---------------------------------------- |---------:|----------:|----------:|------:|--------:|
| LinearCongruentialRandomNumberGenerator | 2.452 ns | 0.0091 ns | 0.0076 ns |  1.00 |    0.00 |
|                          XORShift64Star | 2.570 ns | 0.0317 ns | 0.0281 ns |  1.05 |    0.01 |
|                        XORShift1024Star | 5.612 ns | 0.1440 ns | 0.2669 ns |  2.24 |    0.12 |
