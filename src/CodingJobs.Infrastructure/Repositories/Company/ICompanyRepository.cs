namespace CodingJobs.Infrastructure.Repositories.Company;

public interface ICompanyRepository : IRepository<Domain.Models.Company>
{
    Task<Domain.Models.Company?> GetCompanyWithJobsAsync(int id);
}