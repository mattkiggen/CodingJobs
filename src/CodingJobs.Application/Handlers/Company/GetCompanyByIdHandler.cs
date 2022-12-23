using AutoMapper;
using CodingJobs.Application.Queries.Company;
using CodingJobs.Contracts.Responses.Company;
using CodingJobs.Infrastructure.Database;
using Mediator;

namespace CodingJobs.Application.Handlers.Company;

public class GetCompanyByIdHandler : IRequestHandler<GetCompanyByIdQuery, CompanyWithJobsResponse?>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCompanyByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async ValueTask<CompanyWithJobsResponse?> Handle(GetCompanyByIdQuery query, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.CompanyRepository.GetCompanyWithJobs(query.Id);
        return result != null ? _mapper.Map<CompanyWithJobsResponse>(result) : null;
    }
}