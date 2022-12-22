using AutoMapper;
using CodingJobs.Application.Commands.Company;
using CodingJobs.Contracts.Company.Responses;
using CodingJobs.Infrastructure.Database;
using Mediator;

namespace CodingJobs.Application.Handlers.Company;

public class AddCompanyHandler : IRequestHandler<AddCompanyCommand, CompanyResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public AddCompanyHandler(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    public async ValueTask<CompanyResponse> Handle(AddCompanyCommand command, CancellationToken cancellationToken)
    {
        var company = _mapper.Map<Domain.Models.Company>(command.Request);
        var result = await _unitOfWork.CompanyRepository.AddAsync(company);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<CompanyResponse>(result);
    }
}