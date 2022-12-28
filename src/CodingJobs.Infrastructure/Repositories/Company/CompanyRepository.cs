using System.Linq.Expressions;
using CodingJobs.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace CodingJobs.Infrastructure.Repositories.Company;

public class CompanyRepository : ICompanyRepository
{
    private readonly ApplicationDbContext _context;

    public CompanyRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<ICollection<Domain.Models.Company>> GetAllAsync()
    {
        return await _context.Companies.AsNoTracking().ToListAsync();
    }

    public async Task<Domain.Models.Company?> FindAsync(Expression<Func<Domain.Models.Company, bool>> predicate)
    {
        return await _context.Companies.FirstOrDefaultAsync(predicate);
    }

    public async Task<Domain.Models.Company> AddAsync(Domain.Models.Company newCompany)
    {
        var result = await _context.Companies.AddAsync(newCompany);
        return result.Entity;
    }

    public async Task<Domain.Models.Company?> UpdateAsync(Domain.Models.Company company)
    {
        var result = await FindAsync(x => x.CompanyId == company.CompanyId);
        
        if (result is not null) _context.Entry(result).CurrentValues.SetValues(company);

        return result;
    }

    public async Task<bool> RemoveByIdAsync(int id)
    {
        var company = await FindAsync(c => c.CompanyId == id);
        if (company == null) return false;
        _context.Companies.Remove(company);
        return true;
    }

    public async Task<Domain.Models.Company?> GetCompanyWithJobsAsync(int id)
    {
        var result = await _context.Companies
            .Include(c => c.Jobs)
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.CompanyId == id);
        
        return result;
    }
}