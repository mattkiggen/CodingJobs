using CodingJobs.Contracts.Requests.Company;
using FluentValidation;

namespace CodingJobs.Application.Validators;

public class AddCompanyRequestValidator : AbstractValidator<AddCompanyRequest>
{
    public AddCompanyRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.About).NotEmpty();
        RuleFor(x => x.Location).NotEmpty();
        RuleFor(x => x.Slug).NotEmpty();

        // Todo: We need regex that allows only domains and not full url paths.
        // ex: (https://company.com/seo-slug should not be allowed)
        RuleFor(x => x.WebsiteUrl)
            .Matches(@"^https://.+$")
            .WithMessage("URL must only contain domain name. Example: https://company.com");
    }
}