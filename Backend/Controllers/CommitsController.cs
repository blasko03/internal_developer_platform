using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/commits")]
public class CommitsController : ControllerBase
{
    /*
    private readonly ILogger<CommitsController> _logger;

    public CommitsController(ILogger<CommitsController> logger)
    {
        _logger = logger;
    }
    */
    [HttpGet("get-commits")]
    public Task<Core.Code.ICommit[]> Get()
    {
        return new Core.Code.Github.Commits().GetCommits(owner: "nodejs", repo: "node");
    }
}
