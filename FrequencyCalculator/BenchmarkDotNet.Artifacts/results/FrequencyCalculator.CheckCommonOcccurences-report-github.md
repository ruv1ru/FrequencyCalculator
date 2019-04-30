``` ini

BenchmarkDotNet=v0.11.5, OS=macOS Sierra 10.12.6 (16G1815) [Darwin 16.7.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=2.2.106
  [Host]     : .NET Core 2.2.4 (CoreCLR 4.6.27521.02, CoreFX 4.6.27521.01), 64bit RyuJIT
  DefaultJob : .NET Core 2.2.4 (CoreCLR 4.6.27521.02, CoreFX 4.6.27521.01), 64bit RyuJIT


```
|                       Method |        Mean |      Error |     StdDev |
|----------------------------- |------------:|-----------:|-----------:|
|       BmGetMostCommonViaLinq |    10.21 ms |  0.1408 ms |  0.1317 ms |
|        BmGetMostCommonViaDic | 1,006.71 ms | 14.4683 ms | 13.5337 ms |
| BmGetMostCommonViaDoubleLoop | 2,875.14 ms | 34.4142 ms | 28.7374 ms |
| BmGetMostCommonViaSubLoopDic |   293.32 ms |  5.7287 ms | 10.8995 ms |
