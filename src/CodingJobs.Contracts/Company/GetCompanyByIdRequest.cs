using Mediator;

namespace CodingJobs.Contracts.Company;

public class GetCompanyByIdRequest : IRequest<CompanyResponse?>
{
    public int Id { get; }

    public GetCompanyByIdRequest(int id)
    {
        Id = id;
    }
}