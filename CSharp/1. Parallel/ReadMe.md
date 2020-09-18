``` ini

BenchmarkDotNet=v0.12.1, OS=ubuntu 20.04
Intel Core i7-9700K CPU 3.60GHz (Coffee Lake), 1 CPU, 8 logical and 8 physical cores
.NET Core SDK=3.1.402
  [Host]        : .NET Core 3.1.8 (CoreCLR 4.700.20.41105, CoreFX 4.700.20.41903), X64 RyuJIT
  .NET Core 3.1 : .NET Core 3.1.8 (CoreCLR 4.700.20.41105, CoreFX 4.700.20.41903), X64 RyuJIT

Job=.NET Core 3.1  Runtime=.NET Core 3.1  

```
| Method |        N |          Mean |         Error |        StdDev |        Median |
|------- |--------- |--------------:|--------------:|--------------:|--------------:|
|  **FuncA** |     **1000** |      **8.115 μs** |     **0.2292 μs** |     **0.6685 μs** |      **8.238 μs** |
|  FuncC |     1000 |     34.618 μs |     0.6902 μs |     1.3462 μs |     34.636 μs |
|  FuncB |     1000 |      1.221 μs |     0.0083 μs |     0.0074 μs |      1.219 μs |
|  **FuncA** | **10000000** | **24,401.008 μs** | **1,764.6671 μs** | **5,203.1606 μs** | **25,886.722 μs** |
|  FuncC | 10000000 |  5,949.350 μs |    54.8800 μs |    51.3348 μs |  5,938.327 μs |
|  FuncB | 10000000 | 12,455.040 μs |   122.9161 μs |    95.9648 μs | 12,434.055 μs |
