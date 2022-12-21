using AutoMapper;
using CodingJobs.Contracts.Company;
using CodingJobs.Infrastructure.Database;
using Mediator;

namespace CodingJobs.Application.Company;

public class AddCompanyHandler : IRequestHandler<AddCompanyRequest, CompanyResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public AddCompanyHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    public async ValueTask<CompanyResponse> Handle(AddCompanyRequest request, CancellationToken cancellationToken)
    {
        var company = _mapper.Map<Domain.Models.Company>(request);
        var result = await _unitOfWork.CompanyRepository.AddAsync(company);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<CompanyResponse>(result);
    }
}