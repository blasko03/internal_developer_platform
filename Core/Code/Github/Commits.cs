﻿using System.Text.Json;
using AppRunner.Core.Code.Github.JsonParsing;

namespace AppRunner.Core.Code.Github;

public class Commits : ICommits
{
    private IHttpClientWrapper Client { get; set; }
    public Commits(IHttpClientWrapper? client = null)
    {
        if (client != null)
        {
            Client = client;
        }
        else
        {
            Client = new HttpClientWrapped();
        }
    }
    public async Task<ICommit[]> GetCommits(string owner, string repo)
    {
        var fileString = await Client.GetStringAsync($"https://api.github.com/repos/{owner}/{repo}/commits");
        var commits = JsonSerializer.Deserialize<CommitResponse[]>(fileString, SnakeCaseJsonSerializer.Options()) ?? throw new Exception("json is null");
        return commits.Select(commit => (Commit)commit).ToArray();
    }
}
