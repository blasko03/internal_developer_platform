namespace Core;
public interface ICommit
{
    string Id { get; set; }
    string Description { get; set; }
}

public interface ICommits
{
    public Task<ICommit[]> GetCommits(string owner, string repo);
}
