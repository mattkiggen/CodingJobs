using CodingJobs.Infrastructure.Repositories;

namespace CodingJobs.Infrastructure.Database;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public ICompanyRepository CompanyRepository { get; }

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        CompanyRepository = new CompanyRepository(_context);
    }
    
    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}