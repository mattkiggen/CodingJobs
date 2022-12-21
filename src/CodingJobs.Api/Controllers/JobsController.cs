using Microsoft.AspNetCore.Mvc;

namespace CodingJobs.Api.Controllers;

[ApiController]
[Route("api/jobs")]
public class JobsController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetJobs()
    {
        return Ok("Jobs by pages?");
    }
}