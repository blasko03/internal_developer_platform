namespace AppRunner.Core.Code.Github;

public class Pipeline : IPipeline
{
    public required long Id { get; set; }
    public required string Message { get; set; }
}
