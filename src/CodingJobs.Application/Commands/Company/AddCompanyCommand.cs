using CodingJobs.Contracts.Company.Requests;
using CodingJobs.Contracts.Company.Responses;
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