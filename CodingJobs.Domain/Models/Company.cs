using System.ComponentModel.DataAnnotations;

namespace CodingJobs.Domain.Models;

public class Company
{
    public int CompanyId { get; set; }

    [Required] public string Name { get; set; } = null!;

    [Required] public string About { get; set; } = null!;

    [Required] public string WebsiteUrl { get; set; } = null!;
    
    [Required] public int AddressId { get; set; }
}