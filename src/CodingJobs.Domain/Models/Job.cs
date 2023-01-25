using System.ComponentModel.DataAnnotations;
using CodingJobs.Domain.Enums;

namespace CodingJobs.Domain.Models;

public class Job
{
    public int JobId { get; set; }
    [Required] public string Title { get; set; } = null!;
    [Required] public string Description { get; set; } = null!;
    [Required] public string ApplicationUrl { get; set; } = null!;
    [Required] public EmploymentTypes EmploymentType { get; set; } = null!;
    [Required] public int CompanyId { get; set; }
    public DateTime PublishedOn { get; set; } = DateTime.Now;
    [Required] public DateTime ExpiresOn { get; set; }
    [Required] public ICollection<Skill> Skills { get; set; } = null!;
}