using CodingJobs.Contracts.Responses.Job;

namespace CodingJobs.Contracts.Responses.Company;

public class CompanyWithJobsResponse
{
    public int CompanyId { get; set; }
    public string Name { get; set; } = null!;
    public string About { get; set; } = null!;
    public string Location { get; set; } = null!;
    public string Slug { get; set; } = null!;
    public string? WebsiteUrl { get; set; }
    public List<JobResponse>? Jobs { get; set; }
}