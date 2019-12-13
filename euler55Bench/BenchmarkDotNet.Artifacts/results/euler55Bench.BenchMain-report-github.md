``` ini

BenchmarkDotNet=v0.12.0, OS=Windows 10.0.18363
Intel Core i7-7500U CPU 2.70GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4075.0), X64 RyuJIT
  Job-OBEJVW : .NET Framework 4.8 (4.8.4075.0), X64 RyuJIT

IterationCount=1  LaunchCount=1  WarmupCount=1  

```
|                                 Method |     Mean | Error |
|--------------------------------------- |---------:|------:|
|                        Run_196_100k_V1 | 11.041 s |    NA |
|                  Run_196_100k_unrolled |  9.310 s |    NA |
| Run_196_100k_PalinAddUnrolledWithArray | 15.513 s |    NA |
|        Run_196_100k_PalinAddTwoStrikes | 17.291 s |    NA |
