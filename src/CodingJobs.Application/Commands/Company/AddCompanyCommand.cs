using CodingJobs.Contracts.Requests.Company;
using CodingJobs.Contracts.Responses.Company;
using LanguageExt.Common;
using Mediator;

namespace CodingJobs.Application.Commands.Company;

public class AddCompanyCommand : IRequest<Result<CompanyResponse>>
{
    public AddCompanyRequest Request { get; }

    public AddCompanyCommand(AddCompanyRequest request)
    {
        Request = request;
    }
}