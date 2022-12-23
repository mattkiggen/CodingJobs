using CodingJobs.Contracts.Responses.Company;
using Mediator;

namespace CodingJobs.Application.Queries.Company;

public class GetCompanyByIdQuery : IRequest<CompanyWithJobsResponse?>
{
    public int Id { get; }

    public GetCompanyByIdQuery(int id)
    {
        Id = id;
    }
}