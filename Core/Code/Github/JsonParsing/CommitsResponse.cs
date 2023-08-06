namespace AppRunner.Core.Code.Github.JsonParsing;

internal class CommitResponse
{
    public static explicit operator Commit(CommitResponse response)
    {
        return new Commit
        {
            Id = response.Sha,
            Message = response.Commit.Message
        };
    }

    public static Commit[] ConvertResponse(CommitResponse[] response)
    {
        return response.Select(element => (Commit)element).ToArray();
    }

    public required string Sha { get; set; }
    public required CommitDettailsJson Commit { get; set; }
}

internal class CommitDettailsJson
{
    public required string Message { get; set; }
}
