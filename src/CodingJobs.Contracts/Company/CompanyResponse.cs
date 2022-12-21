namespace CodingJobs.Contracts.Company;

public class CompanyResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string About { get; set; } = null!;
    public string Location { get; set; } = null!;
    public string Slug { get; set; } = null!;
    
    public uint? NumberOfEmployees { get; set; }
    public string? YearFounded { get; set; }
    public string? CompanyLogoUrl { get; set; }
    public string? WebsiteUrl { get; set; }
    public string? FacebookUrl { get; set; }
    public string? TwitterUrl { get; set; }
    public string? LinkedinUrl { get; set; }
}