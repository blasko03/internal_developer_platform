namespace Core.Github;

public class Commit : ICommit
{
    public required string Id { get; set; }
    public required string Description { get; set; }
}
