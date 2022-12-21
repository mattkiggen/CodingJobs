﻿using System.Linq.Expressions;
using CodingJobs.Domain.Models;
using CodingJobs.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace CodingJobs.Infrastructure.Repositories;

public class CompanyRepository : ICompanyRepository
{
    private readonly ApplicationDbContext _context;

    public CompanyRepository(ApplicationDbContext context)
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

    public async Task<Company> AddAsync(Company newCompany)
    {
        var result = await _context.Companies.AddAsync(newCompany);
        return result.Entity;
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