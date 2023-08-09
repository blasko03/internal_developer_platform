using AppRunner.Core.Code.Github;
using NSubstitute;
using Xunit;

namespace AppRunner.Core.UnitTests.Pipelines;

public class CallGetPipelines
{
    private static Task<string> TestData()
    {
        return File.ReadAllTextAsync(Path.Combine("test_files", "get_pipelines.json"));
    }

    [Fact]
    public async Task GetsPipelinesFromService()
    {
        var httpClientMock = Substitute.For<IHttpClientWrapper>();
        httpClientMock.GetStringAsync(default!).ReturnsForAnyArgs(TestData());
        Assert.True((await new Code.Github.Pipelines(httpClientMock).GetPipelines("nodejs", "node")).Length > 0, "Should get an array of pipelines");
    }
}
