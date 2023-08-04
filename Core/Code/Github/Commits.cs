using System.Text.Json;

namespace Core.Github;

public class Commits : ICommits
{
    public async Task<ICommit[]> GetCommits(string owner, string repo)
    {
        var commits = JsonSerializer.Deserialize<JsonElement[]>(await Client.Get().GetStringAsync($"https://api.github.com/repos/{owner}/{repo}/commits")) ?? throw new Exception("AAAAAAA");
        return commits.Select(commit => new Commit
        {
            Id = commit.GetProperty("sha").ToString(),
            Description = commit.GetProperty("commit").GetProperty("message").ToString()
        }).ToArray();
    }
}
