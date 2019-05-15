# FrequencyCalculator


Function that takes an array of integers, and returns an array of integers containing those integers which are most common in the input array.


|                       Method |        Mean |      Error |     StdDev |
|----------------------------- |------------:|-----------:|-----------:|
|       BmGetMostCommonViaLinq |    10.21 ms |  0.1408 ms |  0.1317 ms |
|        BmGetMostCommonViaDic | 1,006.71 ms | 14.4683 ms | 13.5337 ms |
| BmGetMostCommonViaDoubleLoop | 2,875.14 ms | 34.4142 ms | 28.7374 ms |
| BmGetMostCommonViaSubLoopDic |   293.32 ms |  5.7287 ms | 10.8995 ms |
