using System.ComponentModel.DataAnnotations;

namespace CodingJobs.Domain.Models;

public class Skill
{
    public int SkillId { get; set; }
    [Required] public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public ICollection<Job>? Jobs { get; set; }
}