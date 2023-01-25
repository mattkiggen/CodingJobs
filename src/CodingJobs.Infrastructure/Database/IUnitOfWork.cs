using CodingJobs.Infrastructure.Repositories.Company;
using CodingJobs.Infrastructure.Repositories.Job;
using CodingJobs.Infrastructure.Repositories.Skill;

namespace CodingJobs.Infrastructure.Database;

public interface IUnitOfWork
{
    ICompanyRepository CompanyRepository { get; }
    IJobRepository JobRepository { get; }
    ISkillRepository SkillRepository { get; }
    Task<int> SaveChangesAsync();
}