using CodingJobs.Contracts.Company;
using Mediator;

namespace CodingJobs.Application.Company;

public class AddCompanyHandler : IRequestHandler<AddCompanyRequest, AddCompanyResponse>
{
    public ValueTask<AddCompanyResponse> Handle(AddCompanyRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}