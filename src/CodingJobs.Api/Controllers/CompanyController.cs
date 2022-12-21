using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodingJobs.Api.Controllers;

[ApiController]
[Route("api/companies")]
public class CompanyController : ControllerBase
{

    public CompanyController()
    {
        
    }

    [HttpGet]
    public async Task<IActionResult> GetCompanies()
    {
        return Ok("companies");
    }

    [HttpPost]
    [Authorize("create:companies")]
    public async Task<IActionResult> AddNewCompany()
    {
        var id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
        return Ok(id?.Value);
    }
}