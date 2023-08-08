using AppRunner.Core.Code.Github;
using Moq;
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
        var httpClientMock = new Mock<IHttpClientWrapper>();
        httpClientMock.Setup(p => p.GetStringAsync(It.IsAny<Uri>())).Returns(TestData());
        Assert.IsTrue((await new Code.Github.Commits(httpClientMock.Object).GetCommits("nodejs", "node")).Length > 0, "Should get an array of commits");
    }
}
