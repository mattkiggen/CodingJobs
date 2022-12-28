using CodingJobs.Contracts.Requests.Company;
using CodingJobs.Contracts.Responses.Company;
using Mediator;

namespace CodingJobs.Application.Commands.Company;

public class AddCompanyCommand : IRequest<CompanyResponse>
{
    public AddCompanyRequest Request { get; }

    public AddCompanyCommand(AddCompanyRequest request)
    {
        Request = request;
    }
}