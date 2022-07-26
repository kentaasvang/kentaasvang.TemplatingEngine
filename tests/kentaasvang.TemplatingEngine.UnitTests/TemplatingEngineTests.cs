using Xunit;

namespace kentaasvang.TemplatingEngine.UnitTests;

public class TemplatingEngineTests
{
    [Fact]
    public void LoadTemplateTest()
    {
        TemplatingEngine templatingEngine = new();
        const string template = "abcdefghijklmnopqrstuvwxyzæøå";
        templatingEngine.LoadTemplate(template);
        Assert.Equal(templatingEngine.Template, template);
    }
}