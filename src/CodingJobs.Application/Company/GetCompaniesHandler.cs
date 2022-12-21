using AutoMapper;
using CodingJobs.Contracts.Company;
using CodingJobs.Infrastructure.Database;
using Mediator;

namespace CodingJobs.Application.Company;

public class GetCompaniesHandler : IRequestHandler<GetCompaniesRequest, ICollection<CompanyResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCompaniesHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async ValueTask<ICollection<CompanyResponse>> Handle(GetCompaniesRequest request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.CompanyRepository.GetAllAsync();
        return result.Select(c => _mapper.Map<CompanyResponse>(c)).ToList();
    }
}