using System.ComponentModel.DataAnnotations;
using CodingJobs.Contracts.Company.Responses;
using Mediator;

namespace CodingJobs.Contracts.Company.Requests;

public class AddCompanyRequest : IRequest<CompanyResponse>
{
    [Required] public string Name { get; set; } = null!;
    [Required] public string About { get; set; } = null!;
    [Required] public string Location { get; set; } = null!;
    [Required] public string Slug { get; set; } = null!;
    
    public uint? NumberOfEmployees { get; set; }
    public string? YearFounded { get; set; }
    public string? CompanyLogoUrl { get; set; }
    public string? WebsiteUrl { get; set; }
    public string? FacebookUrl { get; set; }
    public string? TwitterUrl { get; set; }
    public string? LinkedinUrl { get; set; }
}