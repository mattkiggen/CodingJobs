using System.Linq.Expressions;
using CodingJobs.Domain.Models;
using CodingJobs.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace CodingJobs.Infrastructure.Repositories;

public class CompanyRepository : ICompanyRepository
{
    private readonly AppDbContext _context;

    public CompanyRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<ICollection<Company>> GetAllAsync()
    {
        return await _context.Companies.ToListAsync();
    }

    public async Task<Company?> FindAsync(Expression<Func<Company, bool>> predicate)
    {
        return await _context.Companies.FirstOrDefaultAsync(predicate);
    }

    public async Task AddAsync(Company newCompany)
    {
        await _context.Companies.AddAsync(newCompany);
    }

    public async Task UpdateAsync(Company company)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(Company t)
    {
        throw new NotImplementedException();
    }

    public Task<Company> GetCompanyWithJobs()
    {
        throw new NotImplementedException();
    }
}