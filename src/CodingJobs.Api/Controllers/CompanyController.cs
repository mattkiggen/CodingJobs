using CodingJobs.Application.Commands.Company;
using CodingJobs.Application.Queries.Company;
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
    public async Task<IActionResult> GetAllCompanies()
    {
        var query = new GetAllCompaniesQuery();
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCompanyById([FromRoute] int id)
    {
        var query = new GetCompanyByIdQuery(id);
        var response = await _mediator.Send(query);
        return response != null ? Ok(response) : NotFound();
    }

    [HttpPost]
    [Authorize("create:companies")]
    public async Task<IActionResult> AddNewCompany([FromBody] AddCompanyRequest request)
    {
        var command = new AddCompanyCommand(request);
        var response = await _mediator.Send(command);
        return Created($"/api/companies/{response.Id}", response);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCompanyById([FromRoute] int id, [FromBody] UpdateCompanyRequest request)
    {
        var command = new UpdateCompanyCommand(id, request);
        var response = await _mediator.Send(command);
        return response != null ? Ok(response) : NotFound();
    }
}