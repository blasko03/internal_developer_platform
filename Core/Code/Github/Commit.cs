namespace Core.Code.Github;

public class Commit : ICommit
{
    public required string Id { get; set; }
    public required string Message { get; set; }
}
