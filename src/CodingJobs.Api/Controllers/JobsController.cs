using CodingJobs.Application.Commands.Job;
using CodingJobs.Contracts.Requests.Job;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace CodingJobs.Api.Controllers;

[ApiController]
[Route("api/jobs")]
public class JobsController : ControllerBase
{
    private readonly IMediator _mediator;

    public JobsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetJobs()
    {
        return Ok("Jobs by pages?");
    }

    [HttpPost]
    public async Task<IActionResult> CreateJob([FromBody] AddJobRequest request)
    {
        Console.WriteLine(request.EmploymentType);
        var command = new AddJobCommand(request);
        var response = await _mediator.Send(command);
        return Ok(response);
    }
}