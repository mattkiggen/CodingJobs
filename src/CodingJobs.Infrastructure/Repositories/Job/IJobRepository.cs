namespace CodingJobs.Infrastructure.Repositories.Job;

public interface IJobRepository : IRepository<Domain.Models.Job>
{
    Task<Domain.Models.Job?> GetJobWithCompanyById(int id);
}