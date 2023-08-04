using System.Net.Http.Headers;

namespace Core.Github;

public class Client
{
    public static HttpClient Get()
    {
        HttpClient client = new();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
        return client;
    }
}
