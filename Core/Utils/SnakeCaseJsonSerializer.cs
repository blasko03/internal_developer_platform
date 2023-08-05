using System.Text.Json;

namespace AppRunner.Core;

public class SnakeCaseJsonSerializer : JsonNamingPolicy
{
    public override string ConvertName(string name)
    {
        return ToUnderscoreCase(name);
    }
    public static string ToUnderscoreCase(string str)
    {
        return string.Concat((str ?? string.Empty)
                     .Select((x, i) => i > 0
                                       && str != null
                                       && i < str.Length - 1
                                       && char.IsUpper(x)
                                       && !char.IsUpper(str[i - 1]) ? $"_{x}" : x.ToString()))
                     .ToLower();
    }

    public static Func<JsonSerializerOptions> Options => () => new JsonSerializerOptions
    {
        PropertyNamingPolicy = new SnakeCaseJsonSerializer()
    };
}
