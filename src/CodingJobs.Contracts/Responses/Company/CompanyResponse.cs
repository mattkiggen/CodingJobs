namespace CodingJobs.Contracts.Responses.Company;

public class CompanyResponse
{
    public int CompanyId { get; set; }
    public string Name { get; set; } = null!;
    public string About { get; set; } = null!;
    public string Location { get; set; } = null!;
    public string Slug { get; set; } = null!;
    public string? WebsiteUrl { get; set; }
}