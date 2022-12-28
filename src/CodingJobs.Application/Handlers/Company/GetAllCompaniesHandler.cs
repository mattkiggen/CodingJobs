using AutoMapper;
using CodingJobs.Application.Queries.Company;
using CodingJobs.Contracts.Responses.Company;
using CodingJobs.Infrastructure.Database;
using Mediator;

namespace CodingJobs.Application.Handlers.Company;

public class GetAllCompaniesHandler : IRequestHandler<GetAllCompaniesQuery, ICollection<CompanyResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllCompaniesHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async ValueTask<ICollection<CompanyResponse>> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.CompanyRepository.GetAllAsync();
        return result.AsParallel().Select(c => _mapper.Map<CompanyResponse>(c)).ToList();
    }
}