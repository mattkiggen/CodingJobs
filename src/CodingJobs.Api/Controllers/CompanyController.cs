using CodingJobs.Contracts.Company;
using CodingJobs.Contracts.Company.Requests;
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
        var response = await _mediator.Send(new GetCompaniesRequest());
        return Ok(response);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCompanyById([FromRoute] int id)
    {
        var response = await _mediator.Send(new GetCompanyByIdRequest(id));
        if (response is null) return NotFound();
        return Ok(response);
    }

    [HttpPost]
    [Authorize("create:companies")]
    public async Task<IActionResult> AddNewCompany([FromBody] AddCompanyRequest request)
    {
        var response = await _mediator.Send(request);
        return Created($"/api/companies/{response.Id}", response);
    }
}