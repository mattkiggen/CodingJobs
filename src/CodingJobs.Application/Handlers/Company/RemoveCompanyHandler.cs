using CodingJobs.Application.Commands.Company;
using CodingJobs.Infrastructure.Database;
using Mediator;

namespace CodingJobs.Application.Handlers.Company;

public class RemoveCompanyHandler : IRequestHandler<RemoveCompanyCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoveCompanyHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async ValueTask<bool> Handle(RemoveCompanyCommand command, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.CompanyRepository.RemoveByIdAsync(command.Id);
        if (result) await _unitOfWork.SaveChangesAsync();
        return result;
    }
}