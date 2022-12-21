using AutoMapper;
using CodingJobs.Contracts.Company;
using CodingJobs.Contracts.Company.Requests;
using CodingJobs.Contracts.Company.Responses;
using CodingJobs.Infrastructure.Database;
using Mediator;

namespace CodingJobs.Application.Company;

public class GetCompanyByIdHandler : IRequestHandler<GetCompanyByIdRequest, CompanyResponse?>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCompanyByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async ValueTask<CompanyResponse?> Handle(GetCompanyByIdRequest request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.CompanyRepository.FindAsync(c => c.CompanyId == request.Id);
        return result is null ? null : _mapper.Map<CompanyResponse>(result);
    }
}