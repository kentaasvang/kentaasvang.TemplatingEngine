# 🆕 TemplatingEngine

## ❓ What is My Project?
A toy implementation of a naive text templating engine

I needed a simple template engine and thought this was a suitable project to learn some nuget-package maintenance and tooling. This project will probably grow over time, but it's implementation with regards to efficiency and memory-usage will be dependent on my personal need - or if I feel I wanna satisfy my curiosity and dive into optimization.

## ⚡ Simple Example
```csharp
TemplateEngine templateEngine = new();
string template = "I love [color] [vegetable] in the [tod]";
Dictionary<string, string> keyVals = new()
{
    {"color": "red"},
    {"vegetable": "potatoes"},
    {"tod": "morning"}
};

template.LoadTemplate(template);
var result = template.Replace(keyVals);
Console.WriteLine(result);
// "I love red potatoes in the morning"
```

## Benchmarks
```ini
// * Summary *

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19044.1826 (21H2)
Intel Core i7-7700HQ CPU 2.80GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.202
  [Host]     : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT
  DefaultJob : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT


|  Method |     Mean |   Error |   StdDev |   Median |  Gen 0 | Allocated |
|-------- |---------:|--------:|---------:|---------:|-------:|----------:|
| Replace | 392.5 ns | 7.83 ns | 20.21 ns | 385.1 ns | 0.2623 |     824 B |

// * Legends *
  Mean      : Arithmetic mean of all measurements
  Error     : Half of 99.9% confidence interval
  StdDev    : Standard deviation of all measurements
  Median    : Value separating the higher half of all measurements (50th percentile)
  Gen 0     : GC Generation 0 collects per 1000 operations
  Allocated : Allocated memory per single operation (managed only, inclusive, 1KB = 1024B)
  1 ns      : 1 Nanosecond (0.000000001 sec)
```

## 🤝 Collaborate with My Project
If you have nothing better to do, sure. Fork -> checkout new branch -> commit changes -> PR 
