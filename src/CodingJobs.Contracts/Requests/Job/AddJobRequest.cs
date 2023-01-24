using System.Text.Json.Serialization;
using Ardalis.SmartEnum.SystemTextJson;
using CodingJobs.Domain.Enums;

namespace CodingJobs.Contracts.Requests.Job;

public class AddJobRequest
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string ApplicationUrl { get; set; } = null!;
    
    [JsonConverter(typeof(SmartEnumNameConverter<EmploymentTypes, int>))]
    public EmploymentTypes EmploymentType { get; set; }
    
    public int CompanyId { get; set; }
    public DateTime ExpiresOn { get; set; }
    public ICollection<int> Skills { get; set; } = null!;
}