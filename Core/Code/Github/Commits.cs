using System.Text.Json;
using Core.Code.Github.JsonParsing;

namespace AppRunner.Core.Code.Github;

public class Commits : ICommits
{
    public async Task<ICommit[]> GetCommits(string owner, string repo)
    {
        var fileString = await Client.Get().GetStringAsync($"https://api.github.com/repos/{owner}/{repo}/commits");
        var commits = JsonSerializer.Deserialize<CommitResponse[]>(fileString, SnakeCaseJsonSerializer.Options()) ?? throw new Exception("json is null");
        return commits.Select(commit => (Commit)commit).ToArray();
    }
}
