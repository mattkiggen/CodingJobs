using CodingJobs.Domain.Models;

namespace CodingJobs.Infrastructure.Repositories;

public interface ICompanyRepository : IRepository<Company>
{
    Task<Company?> GetCompanyWithJobs(int id);
}