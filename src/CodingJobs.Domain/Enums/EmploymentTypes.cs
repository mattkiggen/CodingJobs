using Ardalis.SmartEnum;

namespace CodingJobs.Domain.Enums;

public sealed class EmploymentTypes : SmartEnum<EmploymentTypes>
{
    private EmploymentTypes(string name, int value) : base(name, value)
    {
    }
    
    public static readonly EmploymentTypes Permanent = new("Permanent", 1);
    public static readonly EmploymentTypes FixedTerm = new("FixedTerm", 2);
}