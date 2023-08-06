namespace AppRunner.Core.Code.Github.JsonParsing;

internal class PipelinesResponse
{
    public static explicit operator PipelinesRes(PipelinesResponse element)
    {
        return new PipelinesRes
        {
            TotalCount = element.TotalCount,
            PipelineRuns = element.WorkflowRuns.Select(wr => (Pipeline)wr).ToArray()
        };
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
            Id = "element.TotalCount,",
            Message = element.Name
        };
    }
    public required string Name { get; set; }
}
