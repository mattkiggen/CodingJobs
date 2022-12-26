using CodingJobs.Contracts.Responses.Job;

namespace CodingJobs.Contracts.Responses.Company;

public class CompanyWithJobsResponse
{
    public int CompanyId { get; set; }
    public string Name { get; set; } = null!;
    public string About { get; set; } = null!;
    public string Location { get; set; } = null!;
    public string Slug { get; set; } = null!;
    
    public int? NumberOfEmployees { get; set; }
    public string? YearFounded { get; set; }
    public string? CompanyLogoUrl { get; set; }
    public string? WebsiteUrl { get; set; }
    public string? FacebookUrl { get; set; }
    public string? TwitterUrl { get; set; }
    public string? LinkedinUrl { get; set; }

    public List<JobResponse>? Jobs { get; set; }
}