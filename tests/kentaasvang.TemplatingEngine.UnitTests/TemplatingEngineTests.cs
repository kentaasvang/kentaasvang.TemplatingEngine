using System.Collections.Generic;
using Xunit;

namespace kentaasvang.TemplatingEngine.UnitTests;

public class TemplatingEngineTests
{
    [Fact]
    public void HappyPathTest()
    {
        TemplatingEngine templatingEngine = new();
        const string template = "abcdefghi[key]jklmnopqrstuvwxyzæøå";
        templatingEngine.LoadTemplate(template);

        var actual = templatingEngine.Replace(new Dictionary<string, string>{{"key", "value"}});
        const string expected = "abcdefghivaluejklmnopqrstuvwxyzæøå";
            
        Assert.Equal(templatingEngine.Template, template);
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void HappyPath_WithSingleAngelBrackets()
    {
        TemplatingEngine templatingEngine = new();
        templatingEngine.UseSingleAngelBrackets();
        
        const string template = "abcdefghi{key}jklmnopqrstuvwxyzæøå";
        templatingEngine.LoadTemplate(template);

        var actual = templatingEngine.Replace(new Dictionary<string, string>{{"key", "value"}});
        const string expected = "abcdefghivaluejklmnopqrstuvwxyzæøå";
            
        Assert.Equal(templatingEngine.Template, template);
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void HappyPath_WithEscapeCharacter()
    {
        TemplatingEngine templatingEngine = new();
        templatingEngine.WithBackSlashEscapeCharacter();
        
        const string template = @"abcdefghi\[key]jklmnopqrstuvwxyzæøå";
        templatingEngine.LoadTemplate(template);

        var actual = templatingEngine.Replace(new Dictionary<string, string>{{"key", "value"}});
        const string expected = @"abcdefghi[key]jklmnopqrstuvwxyzæøå";
            
        Assert.Equal(templatingEngine.Template, template);
        Assert.Equal(expected, actual);
    }
}