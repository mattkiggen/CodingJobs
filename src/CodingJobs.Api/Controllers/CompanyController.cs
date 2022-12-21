using System.Security.Claims;
using CodingJobs.Contracts.Company;
using Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodingJobs.Api.Controllers;

[ApiController]
[Route("api/companies")]
public class CompanyController : ControllerBase
{
    private readonly IMediator _mediator;

    public CompanyController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetCompanies()
    {
        return Ok("companies");
    }

    [HttpPost]
    [Authorize("create:companies")]
    public async Task<IActionResult> AddNewCompany([FromBody] AddCompanyRequest request)
    {
        var response = await _mediator.Send(request);
        var id = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

        return Created("", response);
    }
}