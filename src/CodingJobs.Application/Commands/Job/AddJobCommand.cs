using CodingJobs.Contracts.Requests.Job;
using Mediator;

namespace CodingJobs.Application.Commands.Job;

public class AddJobCommand : IRequest<bool>
{
    public AddJobRequest Request { get; }

    public AddJobCommand(AddJobRequest request)
    {
        Request = request;
    }
}