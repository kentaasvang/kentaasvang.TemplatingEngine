using System.Collections.Generic;
using Xunit;

namespace kentaasvang.TemplatingEngine.UnitTests;

public class TemplatingEngineTests
{
    [Fact]
    public void HappyPathTest()
    {
        const string template = @"ab\[key]cdefghi[key]jklmnopqrs[key]tuvwxyzæøå";
        var actual = TemplatingEngine.Replace(template, new Dictionary<string, string>{{"key", "value"}});
        const string expected = @"ab\valuecdefghivaluejklmnopqrsvaluetuvwxyzæøå";
            
        Assert.Equal(expected, actual);
    }
    
    // [Fact]
    // public void HappyPath_WithEscapeCharacter()
    // {
    //     const string template = @"abcdefghi\[key]jkl[key]mnopqrst\[key]uvwxyzæøå";
    //     var actual = TemplatingEngine.Replace(template, new Dictionary<string, string>{{"key", "value"}}, true);
    //     const string expected = @"abcdefghi[key]jklvaluemnopqrst[key]uvwxyzæøå";
    //         
    //     Assert.Equal(expected, actual);
    // }
}