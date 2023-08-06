﻿using AppRunner.Core.Code.Github;
using NUnit.Framework;

namespace AppRunner.Core.UnitTests.Commits;

[TestFixture]
public class CallGetCommits
{
    private class HttpClientWrapper : IHttpClientWrapper
    {
        public Task<string> GetStringAsync(string requestUri)
        {
            return File.ReadAllTextAsync(Path.Combine("test_files", "get_commits.json"));
        }
    }
    [Test]
    public async Task GetsCommitsFromService()
    {
        var mockHttpClient = new HttpClientWrapper();
        Assert.IsTrue((await new Code.Github.Commits(mockHttpClient).GetCommits("nodejs", "node")).Length > 0, "Should get an array of commits");
    }
}