using CodingJobs.Infrastructure.Repositories.Company;
using CodingJobs.Infrastructure.Repositories.Job;

namespace CodingJobs.Infrastructure.Database;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public ICompanyRepository CompanyRepository { get; }
    public IJobRepository JobRepository { get; }

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        CompanyRepository = new CompanyRepository(_context);
        JobRepository = new JobRepository(_context);
    }
    
    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}