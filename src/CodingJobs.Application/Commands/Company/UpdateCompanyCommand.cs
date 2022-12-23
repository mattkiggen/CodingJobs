using CodingJobs.Contracts.Requests.Company;
using CodingJobs.Contracts.Responses.Company;
using Mediator;

namespace CodingJobs.Application.Commands.Company;

public class UpdateCompanyCommand : IRequest<CompanyResponse?>
{
    public int Id { get; }
    public UpdateCompanyRequest Request { get; }

    public UpdateCompanyCommand(int id, UpdateCompanyRequest request)
    {
        Id = id;
        Request = request;
    }
}