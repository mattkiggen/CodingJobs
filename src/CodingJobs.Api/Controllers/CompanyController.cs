using CodingJobs.Infrastructure.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodingJobs.Api.Controllers;

[ApiController]
[Route("api/companies")]
public class CompanyController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public CompanyController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> GetCompanies()
    {
        var companies = await _unitOfWork.CompanyRepository.GetAllAsync();
        return Ok(companies);
    }

    [HttpPost]
    [Authorize("create:companies")]
    public async Task<IActionResult> AddNewCompany()
    {
        return Ok("Company has been created");
    }
}