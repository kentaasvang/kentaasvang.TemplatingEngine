using System.Collections.ObjectModel;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace kentaasvang.TemplatingEngine.Benchmark;

[MemoryDiagnoser]
public class Benchmarks
{
    [Benchmark]
    public void Replace()
    {
        var template = "Should be a long ass text [key] with a lot of values";
        Dictionary<string, string> keyVals = new() {{"key", "value"}};
        var result = TemplatingEngine.Replace(template, keyVals);
    }

    static void Main() => BenchmarkRunner.Run<Benchmarks>();
}