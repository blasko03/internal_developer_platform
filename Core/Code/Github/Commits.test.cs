using AppRunner.Core.Code.Github;
using NSubstitute;
using NUnit.Framework;

namespace AppRunner.Core.UnitTests.Commits;

[TestFixture]
public class CallGetCommits
{
    private static Task<string> TestData()
    {
        return File.ReadAllTextAsync(Path.Combine("test_files", "get_commits.json"));
    }
    [Test]
    public async Task GetsCommitsFromService()
    {
        var httpClientMock = Substitute.For<IHttpClientWrapper>();
        httpClientMock.GetStringAsync(default!).ReturnsForAnyArgs(TestData());
        Assert.IsTrue((await new Code.Github.Commits(httpClientMock).GetCommits("nodejs", "node")).Length > 0, "Should get an array of commits");
    }
}
