using CodingJobs.Contracts.Company.Responses;
using Mediator;

namespace CodingJobs.Application.Queries.Company;

public class GetAllCompaniesQuery : IRequest<List<CompanyResponse>>
{
}