using CodingJobs.Contracts.Responses.Company;
using Mediator;

namespace CodingJobs.Application.Queries.Company;

public class GetAllCompaniesQuery : IRequest<List<CompanyResponse>>
{
}