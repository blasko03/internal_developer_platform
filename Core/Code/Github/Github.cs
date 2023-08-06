using System.Collections;
using System.Text.Json;

namespace AppRunner.Core.Code.Github;

public class Github
{
    protected IHttpClientWrapper Client { get; set; }
    public Github(IHttpClientWrapper? client = null)
    {
        if (client != null)
        {
            Client = client;
        }
        else
        {
            Client = new HttpClientWrapped();
        }
    }

    public async Task<dynamic> GetData<TSource, TResult>(string url)
    {
        var fileString = await Client.GetStringAsync(url);
        var data = JsonSerializer.Deserialize<TSource>(fileString, SnakeCaseJsonSerializer.Options())!;
        Console.WriteLine(typeof(TSource));
        if (typeof(TSource).IsArray)
        {
            return ((IEnumerable)data).Cast<object>().Select(commit => (TResult)(dynamic)commit!).ToArray();
        }
        else
        {
            return (TResult)(dynamic)data;
        }
    }
}
