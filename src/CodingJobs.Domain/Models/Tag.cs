using System.ComponentModel.DataAnnotations;

namespace CodingJobs.Domain.Models;

public class Tag
{
    public int TagId { get; set; }
    
    [Required] public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public ICollection<Job>? Jobs { get; set; }
}