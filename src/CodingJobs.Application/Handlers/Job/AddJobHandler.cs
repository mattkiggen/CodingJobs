using CodingJobs.Application.Commands.Job;
using CodingJobs.Contracts.Requests.Job;
using FluentValidation;
using Mediator;

namespace CodingJobs.Application.Handlers.Job;

public class AddJobHandler : IRequestHandler<AddJobCommand, bool>
{
    private readonly IValidator<AddJobRequest> _validator;

    public AddJobHandler(IValidator<AddJobRequest> validator)
    {
        _validator = validator;
    }
    
    public async ValueTask<bool> Handle(AddJobCommand command, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(command.Request, cancellationToken);
        if (!validationResult.IsValid) throw new ValidationException(validationResult.Errors);
        
        // Add to DB
        throw new NotImplementedException();
    }
}