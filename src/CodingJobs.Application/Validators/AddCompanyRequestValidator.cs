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
        
        RuleFor(x => x.NumberOfEmployees)
            .GreaterThan(0)
            .When(x => x.NumberOfEmployees.HasValue)
            .WithMessage("Number of employees must be greater than 0");

        // Todo: Add better regex
        RuleFor(x => x.LinkedinUrl)
            .Matches(@"https:\/\/([\w]+\.)?linkedin\.com\/in\/[A-z0-9_-]+\/?")
            .WithMessage("Must be a valid Linkedin URL");

        // Todo: Validation should match cloudfront url or service we choose for image hosting
        RuleFor(x => x.CompanyLogoUrl)
            .Matches(@"^https://.+$");

        // Todo: We need regex that allows only domains and not full url paths.
        // ex: (https://company.com/seo-slug should not be allowed)
        RuleFor(x => x.WebsiteUrl)
            .Matches(@"^https://.+$")
            .WithMessage("URL must only contain domain name. Example: https://company.com");

        // Todo: Add better regex
        RuleFor(x => x.FacebookUrl)
            .Matches(@"https://facebook\.com\/[a-zA-Z0-9_-]*$")
            .WithMessage("Must be a valid Facebook URL");
        
        // Todo: Add better regex
        RuleFor(x => x.TwitterUrl)
            .Matches(@"https://twitter\.com\/[a-zA-Z0-9_-]*$")
            .WithMessage("Must be a valid Twitter URL");

        // Todo: Maybe we should use a date type instead of just a string?
        RuleFor(x => x.YearFounded).Length(4);
    }
}