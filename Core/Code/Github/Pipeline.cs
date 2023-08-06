namespace AppRunner.Core.Code.Github;

public class Pipeline : IPipeline
{
    public required string Id { get; set; }
    public required string Message { get; set; }
}
