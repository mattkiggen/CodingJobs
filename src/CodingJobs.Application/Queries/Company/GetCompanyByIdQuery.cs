using CodingJobs.Contracts.Company.Responses;
using Mediator;

namespace CodingJobs.Application.Queries.Company;

public class GetCompanyByIdQuery : IRequest<CompanyResponse?>
{
    public int Id { get; }

    public GetCompanyByIdQuery(int id)
    {
        Id = id;
    }
}