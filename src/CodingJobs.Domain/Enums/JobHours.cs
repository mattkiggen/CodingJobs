using Ardalis.SmartEnum;

namespace CodingJobs.Domain.Enums;

public sealed class JobHours : SmartEnum<JobHours>
{
    private JobHours(string name, int value) : base(name, value)
    {
    }

    public static readonly JobHours PartTime = new("PartTime", 1);
    public static readonly JobHours FullTime = new("FullTime", 2);
}