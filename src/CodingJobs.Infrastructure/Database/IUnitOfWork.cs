using CodingJobs.Infrastructure.Repositories.Company;
using CodingJobs.Infrastructure.Repositories.Job;

namespace CodingJobs.Infrastructure.Database;

public interface IUnitOfWork
{
    ICompanyRepository CompanyRepository { get; }
    IJobRepository JobRepository { get; }
    Task<int> SaveChangesAsync();
}