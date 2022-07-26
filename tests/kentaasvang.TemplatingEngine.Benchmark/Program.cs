using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace kentaasvang.TemplatingEngine.Benchmark;

[MemoryDiagnoser]
public class Benchmarks
{
    [Benchmark]
    public void Replace()
    {
        TemplatingEngine templateEngine = new();
        var template = "Should be a long ass text [key] with a lot of values";
        templateEngine.LoadTemplate(template);
        Dictionary<string, string> keyVals = new() {{"key", "value"}};
        var result = templateEngine.Replace(keyVals);
    }


    static void Main() => BenchmarkRunner.Run<Benchmarks>();
}