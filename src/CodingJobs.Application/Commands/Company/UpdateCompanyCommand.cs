using CodingJobs.Contracts.Company.Requests;
using CodingJobs.Contracts.Company.Responses;
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