using AppRunner.Core.Code.Github.JsonParsing;

namespace AppRunner.Core.Code.Github;

public class Commits : Github, ICommits
{
    public Commits(IHttpClientWrapper? client = null) : base(client) { }

    public async Task<ICommit[]> GetCommits(string owner, string repo)
    {
        return await GetData<CommitResponse[], Commit[]>(new UriBuilder($"https://api.github.com/repos/{owner}/{repo}/commits"), CommitResponse.ConvertResponse);
    }
}
