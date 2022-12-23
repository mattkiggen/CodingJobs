using AutoMapper;
using CodingJobs.Application.Commands.Company;
using CodingJobs.Contracts.Responses.Company;
using CodingJobs.Infrastructure.Database;
using Mediator;

namespace CodingJobs.Application.Handlers.Company;

public class UpdateCompanyHandler : IRequestHandler<UpdateCompanyCommand, CompanyResponse?>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateCompanyHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    public async ValueTask<CompanyResponse?> Handle(UpdateCompanyCommand command, CancellationToken cancellationToken)
    {
        var company = _mapper.Map<Domain.Models.Company>(command.Request);
        company.CompanyId = command.Id;
        var result = await _unitOfWork.CompanyRepository.UpdateAsync(company);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.Map<CompanyResponse>(result);
    }
}