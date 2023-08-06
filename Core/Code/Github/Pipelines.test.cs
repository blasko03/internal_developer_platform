using AppRunner.Core.Code.Github;
using NUnit.Framework;

namespace AppRunner.Core.UnitTests.Pipelines;

[TestFixture]
public class CallGetPipelines
{
    private class HttpClientWrapper : IHttpClientWrapper
    {
        public Task<string> GetStringAsync(string requestUri)
        {
            return File.ReadAllTextAsync(Path.Combine("test_files", "get_pipelines.json"));
        }
    }
    [Test]
    public async Task GetsPipelinesFromService()
    {
        var mockHttpClient = new HttpClientWrapper();
        Assert.IsTrue((await new Code.Github.Pipelines(mockHttpClient).GetPipelines("nodejs", "node")).Length > 0, "Should get an array of commits");
    }
}
