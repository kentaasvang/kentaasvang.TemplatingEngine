using System.Text;

namespace kentaasvang.TemplatingEngine;

public class TemplatingEngine
{
    public string Template { get; private set; } = null!;
    private char Start { get; set; } = '[';
    private char End { get; set; } = ']';
    private char Escape { get; set; }
    
    public void LoadTemplate(string template)
    {
        Template = template;
    }
    
    public string Replace(Dictionary<string, string> keywordDict)
    {
        var inKeyword = false;
        var inEscape = false;
        StringBuilder temporaryKeyword = new();
        StringBuilder stringBuilder = new();

        foreach (var character in Template)
        {
            if (inEscape)
            {
                inEscape = false;
                stringBuilder.Append(character);
                continue;
            }

            if (inKeyword)
            {
                if (character != End)
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

            if (character == Escape)
            {
                inEscape = true;
                continue;
            }
            
            if (character != Start || (character != End && !inEscape))
            {
                stringBuilder.Append(character);
                continue;
            }

            if (character == Start)
                inKeyword = true;
        }

        return stringBuilder.ToString();
    }

    public void UseSingleAngelBrackets()
    {
        Start = '{';
        End = '}';
    }

    public void WithBackSlashEscapeCharacter()
    {
        Escape = '\\';
    }
}
