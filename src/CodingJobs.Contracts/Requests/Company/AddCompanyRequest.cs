namespace CodingJobs.Contracts.Requests.Company;

public class AddCompanyRequest
{
    public string Name { get; set; } = default!;
    public string About { get; set; } = default!;
    public string Location { get; set; } = default!;
    public string Slug { get; set; } = default!;
    public string? WebsiteUrl { get; set; }
}