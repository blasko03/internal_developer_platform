namespace Core.Code;
public interface ICommit
{
    string Id { get; set; }
    string Message { get; set; }
}

public interface ICommits
{
    public Task<ICommit[]> GetCommits(string owner, string repo);
}
