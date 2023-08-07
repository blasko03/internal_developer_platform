using AppRunner.Core.Code.Github;
using Moq;
using NUnit.Framework;

namespace AppRunner.Core.UnitTests.Pipelines;

[TestFixture]
public class CallGetPipelines
{
    private static Task<string> TestData()
    {
        return File.ReadAllTextAsync(Path.Combine("test_files", "get_pipelines.json"));
    }

    [Test]
    public async Task GetsPipelinesFromService()
    {
        var httpClientMock = new Mock<IHttpClientWrapper>();
        httpClientMock.Setup(p => p.GetStringAsync(It.IsAny<string>())).Returns(TestData());
        Assert.IsTrue((await new Code.Github.Pipelines(httpClientMock.Object).GetPipelines("nodejs", "node")).Length > 0, "Should get an array of pipelines");
    }
}
