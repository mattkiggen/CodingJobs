using CodingJobs.Domain.Enums;
using CodingJobs.Domain.Models;

namespace CodingJobs.Contracts.Responses.Job;

public class JobResponse
{
    public int JobId { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ApplicationUrl { get; set; } = null!;
    public EmploymentTypes EmploymentType { get; set; } = null!;
    public int CompanyId { get; set; }
    public DateTime PublishedOn { get; set; }
    public DateTime ExpiresOn { get; set; }
    public ICollection<Skill> Skills { get; set; } = null!;
}