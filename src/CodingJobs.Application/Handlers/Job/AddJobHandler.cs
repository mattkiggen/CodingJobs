using AutoMapper;
using CodingJobs.Application.Commands.Job;
using CodingJobs.Contracts.Requests.Job;
using CodingJobs.Contracts.Responses.Job;
using CodingJobs.Infrastructure.Database;
using FluentValidation;
using Mediator;

namespace CodingJobs.Application.Handlers.Job;

public class AddJobHandler : IRequestHandler<AddJobCommand, JobResponse>
{
    private readonly IValidator<AddJobRequest> _validator;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public AddJobHandler(IValidator<AddJobRequest> validator, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _validator = validator;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    public async ValueTask<JobResponse> Handle(AddJobCommand command, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(command.Request, cancellationToken);
        if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);
        
        var job = _mapper.Map<Domain.Models.Job>(command.Request);

        var result = await _unitOfWork.JobRepository.AddAsync(job);
        await _unitOfWork.SaveChangesAsync();
        
        return _mapper.Map<JobResponse>(result);
    }
}