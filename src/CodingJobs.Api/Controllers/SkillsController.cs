using Microsoft.AspNetCore.Mvc;

namespace CodingJobs.Api.Controllers;

[ApiController]
[Route("api/skills")]
public class SkillsController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetSkills()
    {
        
        return Ok("Skills by pages?");
    }
}