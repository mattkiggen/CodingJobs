using CodingJobs.Application.Commands.Company;
using CodingJobs.Application.Queries.Company;
using CodingJobs.Contracts.Requests.Company;
using CodingJobs.Contracts.Responses.Company;
using Mediator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodingJobs.Api.Controllers;

[ApiController]
[Route("api/companies")]
[Produces("application/json")]
[Consumes("application/json")]
public class CompanyController : ControllerBase
{
    private readonly IMediator _mediator;

    public CompanyController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Get a list of companies, does not include their jobs posted
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(List<CompanyResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllCompanies()
    {
        var query = new GetAllCompaniesQuery();
        var response = await _mediator.Send(query);
        return Ok(response);
    }

    /// <summary>
    /// Get details of a company by ID, includes their jobs posted
    /// </summary>
    /// <param name="id"></param>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(CompanyResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCompanyById([FromRoute] int id)
    {
        var query = new GetCompanyByIdQuery(id);
        var result = await _mediator.Send(query);
        return result is null ? NotFound() : Ok(result);
    }

    /// <summary>
    /// Create new company
    /// </summary>
    [HttpPost]
    [Authorize("create:companies")]
    [ProducesResponseType(typeof(CompanyResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> AddNewCompany([FromBody] AddCompanyRequest request)
    {
        var command = new AddCompanyCommand(request);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    /// <summary>
    /// Update a company by ID
    /// </summary>
    [HttpPut("{id:int}")]
    [Authorize("update:companies")]
    [ProducesResponseType(typeof(CompanyResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateCompanyById([FromRoute] int id, [FromBody] UpdateCompanyRequest request)
    {
        var command = new UpdateCompanyCommand(id, request);
        var response = await _mediator.Send(command);
        return response is null ? NotFound() : Ok(response);
    }

    /// <summary>
    /// Remove a company by ID
    /// </summary>
    [HttpDelete("{id:int}")]
    [Authorize("delete:companies")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoveCompanyById([FromRoute] int id)
    {
        var command = new RemoveCompanyCommand(id);
        var response = await _mediator.Send(command);
        return response ? Ok("Company deleted") : NotFound();
    }
}