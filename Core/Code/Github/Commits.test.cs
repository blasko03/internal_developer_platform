using AppRunner.Core.Code.Github;
using NSubstitute;
using Xunit;
namespace AppRunner.Core.UnitTests.Commits;

public class CallGetCommits
{
    private static Task<string> TestData()
    {
        return File.ReadAllTextAsync(Path.Combine("test_files", "get_commits.json"));
    }
    [Fact]
    public async Task GetsCommitsFromService()
    {
        var httpClientMock = Substitute.For<IHttpClientWrapper>();
        httpClientMock.GetStringAsync(default!).ReturnsForAnyArgs(TestData());
        Assert.True((await new Code.Github.Commits(httpClientMock).GetCommits("nodejs", "node")).Length > 0, "Should get an array of commits");
    }
}
