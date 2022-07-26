using System.Text;

namespace kentaasvang.TemplatingEngine;

public class TemplatingEngine
{
    public string Template { get; private set; } = null!;
    
    public void LoadTemplate(string template)
    {
        Template = template;
    }

    public string Replace(Dictionary<string, string> keywordDict)
    {
        var inKeyword = false;
        StringBuilder temporaryKeyword = new();
        StringBuilder stringBuilder = new();

        foreach (var character in Template)
        {
            if (inKeyword)
            {
                if (character is not ']')
                {
                    temporaryKeyword.Append(character);
                    continue;
                }

                if (!keywordDict.TryGetValue(temporaryKeyword.ToString(), out var value))
                    stringBuilder.Append(temporaryKeyword);
                else
                    stringBuilder.Append(value);

                temporaryKeyword.Clear();
                inKeyword = false;
                continue;
            }

            if (character is not '[' or ']')
            {
                stringBuilder.Append(character);
                continue;
            }

            if (character == '[')
                inKeyword = true;
        }

        return stringBuilder.ToString();
    }
}