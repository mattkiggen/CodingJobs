using CodingJobs.Contracts.Company.Responses;
using Mediator;

namespace CodingJobs.Contracts.Company.Requests;

public class GetCompanyByIdRequest : IRequest<CompanyResponse?>
{
    public int Id { get; }

    public GetCompanyByIdRequest(int id)
    {
        Id = id;
    }
}