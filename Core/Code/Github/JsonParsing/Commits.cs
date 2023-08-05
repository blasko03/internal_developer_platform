namespace AppRunner.Core.Code.Github.JsonParsing;

internal class CommitResponse
{
    public static explicit operator Commit(CommitResponse element)
    {
        return new Commit
        {
            Id = element.Sha,
            Message = element.Commit.Message
        };
    }
    public required string Sha { get; set; }
    public required CommitDettailsJson Commit { get; set; }
}

internal class CommitDettailsJson
{
    public required string Message { get; set; }
}
