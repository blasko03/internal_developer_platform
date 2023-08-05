using AppRunner.Core.Code.Github;
using NUnit.Framework;

namespace AppRunner.Core.UnitTests.Commits;

[TestFixture]
public class CallGetCommits
{
    private class HttpClientWrapper : IHttpClientWrapper
    {
        private static async Task<string> GetString()
        {
            await Task.Delay(1);
            return "[{\"sha\": \"dfgdgdfgd\", \"commit\": { \"message\": \"dfgdggrg\" }}]";
        }
        public Task<string> GetStringAsync(string requestUri)
        {
            return GetString();
        }
    }
    [Test]
    public async Task GetsCommitsFromService()
    {
        var mockHttpClient = new HttpClientWrapper();
        Assert.IsTrue((await new Code.Github.Commits(mockHttpClient).GetCommits("nodejs", "node")).Length > 0, "Should get an array of commits");
    }
}
