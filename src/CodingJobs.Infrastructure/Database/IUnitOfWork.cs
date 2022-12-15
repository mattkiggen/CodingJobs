using CodingJobs.Infrastructure.Repositories;

namespace CodingJobs.Infrastructure.Database;

public interface IUnitOfWork
{
    ICompanyRepository CompanyRepository { get; }
    Task<int> SaveChangesAsync();
}