using AutoMapper;
using CodingJobs.Application.Queries.Company;
using CodingJobs.Contracts.Company.Responses;
using CodingJobs.Infrastructure.Database;
using Mediator;

namespace CodingJobs.Application.Handlers.Company;

public class GetCompanyByIdHandler : IRequestHandler<GetCompanyByIdQuery, CompanyResponse?>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCompanyByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async ValueTask<CompanyResponse?> Handle(GetCompanyByIdQuery query, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.CompanyRepository.FindAsync(c => c.CompanyId == query.Id);
        return result is null ? null : _mapper.Map<CompanyResponse>(result);
    }
}