using System.ComponentModel.DataAnnotations;
using CodingJobs.Domain.Enums;

namespace CodingJobs.Domain.Models;

public class Job
{
    public int JobId { get; set; }

    // Content
    [Required] public string Title { get; set; } = null!;
    [Required] public string Description { get; set; } = null!;
    [Required] public string ApplicationUrl { get; set; } = null!;
    
    // Meta
    [Required] public EmploymentTypes EmploymentType { get; set; } = null!;
    [Required] public JobHours JobHours { get; set; } = null!;
    [Required] public int CompanyId { get; set; }
    [Required] public DateTime PublishedOn { get; set; }
    [Required] public DateTime ExpiresOn { get; set; }
    [Required] public ICollection<Skill> Skills { get; set; } = null!;
    [Required] public string Location { get; set; } = null!;
}