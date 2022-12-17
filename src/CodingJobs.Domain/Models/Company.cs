using System.ComponentModel.DataAnnotations;

namespace CodingJobs.Domain.Models;

public class Company
{
    public int CompanyId { get; set; }

    // Details
    [Required] public string Name { get; set; } = null!;
    [Required] public string About { get; set; } = null!;
    [Required] public string Location { get; set; } = null!;
    [Required] public string Slug { get; set; } = null!;
    public uint? NumberOfEmployees { get; set; }
    public string? YearFounded { get; set; }
    public string? CompanyLogoUrl { get; set; }

    // Online presence
    public string? WebsiteUrl { get; set; }
    public string? FacebookUrl { get; set; }
    public string? TwitterUrl { get; set; }
    public string? LinkedinUrl { get; set; }

    // Jobs posted
    public ICollection<Job>? Jobs { get; set; }
}