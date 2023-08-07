using System.Text.Json;

namespace AppRunner.Core.Code.Github;

public class Github
{
    protected IHttpClientWrapper Client { get; set; }
    public Github(IHttpClientWrapper? client = null)
    {
        Client = client ?? new HttpClientWrapper();
    }

    public async Task<TResult> GetData<TSource, TResult>(string url, Func<TSource, TResult> dataConverter)
    {
        var fileString = await Client.GetStringAsync(url);
        var data = JsonSerializer.Deserialize<TSource>(fileString, SnakeCaseJsonSerializer.Options())!;
        return dataConverter(data)!;
    }
}
