using System.ComponentModel.DataAnnotations;

namespace CodingJobs.Contracts.Requests.Company;

public class UpdateCompanyRequest
{
    [Required] public string Name { get; set; } = null!;
    [Required] public string About { get; set; } = null!;
    [Required] public string Location { get; set; } = null!;
    [Required] public string Slug { get; set; } = null!;
    public string? WebsiteUrl { get; set; }
}