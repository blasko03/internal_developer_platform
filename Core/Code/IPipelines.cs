namespace AppRunner.Core.Code;
public interface IPipeline
{
    long Id { get; set; }
    string Message { get; set; }
}

public interface IPipelines
{
    public Task<IPipeline[]> GetPipelines(string owner, string repo);
}

public interface IPipelinesRes
{
    IPipeline[] PipelineRuns { get; set; }
    int TotalCount { get; set; }
}
