using System.ComponentModel.DataAnnotations;
using CodingJobs.Domain.Enums;

namespace CodingJobs.Domain.Models;

public class Job
{
    public int JobId { get; set; }

    [Required]
    public string Title { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;

    [Required]
    public EmploymentType EmploymentType { get; set; }

    [Required]
    public string ApplicationUrl { get; set; } = null!;

    [Required]
    public int CompanyId { get; set; }

    [Required]
    public DateTime ExpiresOn { get; set; }
}