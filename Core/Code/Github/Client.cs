using System.Net.Http.Headers;

namespace AppRunner.Core.Code.Github;
public class HttpClientWrapper : IHttpClientWrapper
{
    private HttpClient HttpClient { get; set; }
    public HttpClientWrapper()
    {
        HttpClient = new HttpClient();
        HttpClient.DefaultRequestHeaders.Accept.Clear();
        HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        HttpClient.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
        // client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Environment.GetEnvironmentVariable("GITHUB_SECRET")}");
    }

    public Task<string> GetStringAsync(string requestUri)
    {
        return HttpClient.GetStringAsync(requestUri);
    }
}

public interface IHttpClientWrapper
{
    Task<string> GetStringAsync(string requestUri);
}
