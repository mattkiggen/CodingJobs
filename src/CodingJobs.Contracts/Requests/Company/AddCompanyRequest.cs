using System.ComponentModel.DataAnnotations;

namespace CodingJobs.Contracts.Requests.Company;

public class AddCompanyRequest
{
    public string Name { get; set; } = default!;
    public string About { get; set; } = default!;
    public string Location { get; set; } = default!;
    public string Slug { get; set; } = default!;
    public int? NumberOfEmployees { get; set; }
    public string? YearFounded { get; set; }
    public string? CompanyLogoUrl { get; set; }
    public string? WebsiteUrl { get; set; }
    public string? FacebookUrl { get; set; }
    public string? TwitterUrl { get; set; }
    public string? LinkedinUrl { get; set; }
}