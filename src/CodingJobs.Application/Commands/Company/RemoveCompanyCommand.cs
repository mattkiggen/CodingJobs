using Mediator;

namespace CodingJobs.Application.Commands.Company;

public class RemoveCompanyCommand : IRequest<bool?>
{
    public int Id { get; }

    public RemoveCompanyCommand(int id)
    {
        Id = id;
    }
}