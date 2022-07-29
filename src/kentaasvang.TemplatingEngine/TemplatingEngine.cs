using System.Text;

namespace kentaasvang.TemplatingEngine;

public static class TemplatingEngine
{
    public static string Replace(string template, Dictionary<string, string> keyvals)
    {
        var           inKeyword        = false;
        StringBuilder temporaryKeyword = new();
        StringBuilder stringBuilder    = new();

        foreach (var character in template)
        {
            if (inKeyword)
            {
                if (character is not ']')
                {
                    temporaryKeyword.Append(character);
                    continue;
                }

                if (!keyvals.TryGetValue(temporaryKeyword.ToString(), out var value))
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
    
    // public static string ReplaceOp(
    //     ReadOnlySpan<char>         template,
    //     Dictionary<string, string> keywordDict,
    //     bool                       useEscape = false
    //     )
    // {
    //     var        inKeyword = false;
    //     var        inEscape  = false;
    //     const char start     = '[';
    //     const char end       = ']';
    //     char?      escape    = useEscape ? '\\' : null;
    //     var        offset    = 0;
    //
    //     // allocate chars on stack, length of template + some padding
    //     Span<char> retVal      = stackalloc char[template.Length + template.Length / 2];
    //     Span<char> tempKeyword = stackalloc char[50];
    //
    //     var i = 0;
    //     for (; i < template.Length; i++)
    //     {
    //         var chr = template[i];
    //
    //         if (inEscape)
    //         {
    //             retVal[i + offset] = chr;
    //             inEscape  = false;
    //             continue;
    //         }
    //
    //         if (inKeyword)
    //         {
    //             if (chr != end)
    //             {
    //                 tempKeyword[++offset] = chr;
    //                 continue;
    //             }
    //
    //             if (!keywordDict.TryGetValue(new string(tempKeyword[..offset]), out var val))
    //             {
    //                 var len = offset;
    //                 for (var j = 0; j <= len; j++)
    //                 {
    //                     var letter = tempKeyword[j];
    //                     retVal[i - (offset-- + 1)] = letter;
    //                 }
    //             }
    //             else
    //             {
    //                 var len = offset;
    //                 for (var j = 0; j < len; j++)
    //                 {
    //                     var letter = val[j];
    //                     retVal[i - (offset-- + 1)] = letter;
    //                 }
    //             }
    //
    //             offset = 0;
    //             tempKeyword.Clear();
    //             inKeyword = false;
    //             continue;
    //         }
    //
    //         if (useEscape && chr == escape)
    //         {
    //             inEscape = true;
    //             // offset--;
    //             continue;
    //         }
    //         
    //         if (chr == start)
    //             inKeyword = true;
    //
    //         if (chr != start && chr != end || !inKeyword)
    //             retVal[i + offset] = chr;
    //     }
    //
    //     return new string(retVal[..(i + offset)]);
    // }
}
