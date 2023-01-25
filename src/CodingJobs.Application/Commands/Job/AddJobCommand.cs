using CodingJobs.Contracts.Requests.Job;
using CodingJobs.Contracts.Responses.Job;
using Mediator;

namespace CodingJobs.Application.Commands.Job;

public class AddJobCommand : IRequest<JobResponse>
{
    public AddJobRequest Request { get; }

    public AddJobCommand(AddJobRequest request)
    {
        Request = request;
    }
}