using AppRunner.Core.Code.Github.JsonParsing;

namespace AppRunner.Core.Code.Github;
public class Pipelines : Github, IPipelines
{
    public Pipelines(IHttpClientWrapper? client = null) : base(client) { }

    public async Task<IPipeline[]> GetPipelines(string owner, string repo)
    {
        return await GetData<PipelinesResponse, Pipeline[]>($"https://api.github.com/repos/{owner}/{repo}/actions/runs", PipelinesResponse.ConvertResponse);
    }
}

public class PipelinesRes : IPipelinesRes
{
    public required IPipeline[] PipelineRuns { get; set; }
    public required int TotalCount { get; set; }
}
