namespace AppRunner.Core.Code.Github.JsonParsing;

internal class PipelinesResponse
{
    public static Pipeline[] ConvertResponse(PipelinesResponse element)
    {
        return element.WorkflowRuns.Select(wr => (Pipeline)wr).ToArray();
    }
    public required int TotalCount { get; set; }
    public required PipelineRunsResponse[] WorkflowRuns { get; set; }
}

internal class PipelineRunsResponse
{
    public static explicit operator Pipeline(PipelineRunsResponse element)
    {
        return new Pipeline
        {
            Id = element.Id,
            Message = element.Name
        };
    }
    public required long Id { get; set; }
    public required string Name { get; set; }
}
