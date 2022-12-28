using CodingJobs.Domain.Models;
using LanguageExt;

namespace CodingJobs.Infrastructure.Repositories;

public interface ICompanyRepository : IRepository<Company>
{
    Task<Company?> GetCompanyWithJobsAsync(int id);
}