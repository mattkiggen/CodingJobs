using CodingJobs.Contracts.Requests.Job;
using FluentValidation;

namespace CodingJobs.Application.Validators.Job;

public class AddJobRequestValidator : AbstractValidator<AddJobRequest>
{
    public AddJobRequestValidator()
    {
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.ApplicationUrl).NotEmpty();
        RuleFor(x => x.EmploymentType).NotEmpty();
        RuleFor(x => x.CompanyId).NotEmpty();
        RuleFor(x => x.ExpiresOn).NotEmpty();
        RuleFor(x => x.Skills).NotEmpty();
    }
}