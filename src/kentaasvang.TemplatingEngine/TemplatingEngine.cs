namespace kentaasvang.TemplatingEngine;

public class TemplatingEngine
{
    public string Template { get; private set; } = null!;
    
    public void LoadTemplate(string template)
    {
        Template = template;
    }
}