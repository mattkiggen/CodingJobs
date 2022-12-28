using CodingJobs.Infrastructure.Repositories;
using CodingJobs.Infrastructure.Repositories.Company;

namespace CodingJobs.Infrastructure.Database;

public interface IUnitOfWork
{
    ICompanyRepository CompanyRepository { get; }
    Task<int> SaveChangesAsync();
}