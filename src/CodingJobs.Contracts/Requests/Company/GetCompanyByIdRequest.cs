using CodingJobs.Contracts.Responses.Company;
using Mediator;

namespace CodingJobs.Contracts.Requests.Company;

public class GetCompanyByIdRequest : IRequest<CompanyResponse?>
{
    public int Id { get; }

    public GetCompanyByIdRequest(int id)
    {
        Id = id;
    }
}