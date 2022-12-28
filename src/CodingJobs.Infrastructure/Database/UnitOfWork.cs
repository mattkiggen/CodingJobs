using CodingJobs.Infrastructure.Repositories;
using CodingJobs.Infrastructure.Repositories.Company;

namespace CodingJobs.Infrastructure.Database;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public ICompanyRepository CompanyRepository { get; }

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        CompanyRepository = new CompanyRepository(_context);
    }
    
    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}