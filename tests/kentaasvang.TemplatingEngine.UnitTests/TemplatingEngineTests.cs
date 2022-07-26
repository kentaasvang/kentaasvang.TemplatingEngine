using System.Collections.Generic;
using Xunit;

namespace kentaasvang.TemplatingEngine.UnitTests;

public class TemplatingEngineTests
{
    [Fact]
    public void HappyPathTest()
    {
        TemplatingEngine templatingEngine = new();
        var template = "abcdefghi[name]jklmnopqrstuvwxyzæøå";
        templatingEngine.LoadTemplate(template);

        var actual = templatingEngine.Replace(new Dictionary<string, string>{{"name", "kent"}});
        var expected = "abcdefghikentjklmnopqrstuvwxyzæøå";
            
        Assert.Equal(templatingEngine.Template, template);
        Assert.Equal(expected, actual);
    }
}