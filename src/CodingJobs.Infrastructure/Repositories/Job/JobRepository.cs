using System.Linq.Expressions;
using CodingJobs.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace CodingJobs.Infrastructure.Repositories.Job;

public class JobRepository : IJobRepository
{
    private readonly ApplicationDbContext _context;

    public JobRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<ICollection<Domain.Models.Job>> GetAllAsync()
    {
        return await _context.Jobs.AsNoTracking().ToListAsync();
    }

    public async Task<Domain.Models.Job?> FindAsync(Expression<Func<Domain.Models.Job, bool>> predicate)
    {
        return await _context.Jobs.FirstOrDefaultAsync(predicate);
    }

    public async Task<Domain.Models.Job> AddAsync(Domain.Models.Job newJob)
    {
        newJob.Skills.ToList().ForEach(s => _context.Attach(s));
        var result = await _context.Jobs.AddAsync(newJob);
        return result.Entity;
    }

    public async Task<Domain.Models.Job?> UpdateAsync(Domain.Models.Job job)
    {
        var result = await FindAsync(x => x.JobId == job.JobId);
        if (result is not null) _context.Entry(result).CurrentValues.SetValues(job);
        return result;
    }

    public async Task<bool> RemoveByIdAsync(int id)
    {
        var result = await FindAsync(x => x.JobId == id);
        if (result is null) return false;
        _context.Jobs.Remove(result);
        return true;
    }

    public async Task<Domain.Models.Job?> GetJobWithCompanyById(int id)
    {
        return await _context.Jobs
            .AsNoTracking()
            .Include(x => x.CompanyId)
            .FirstOrDefaultAsync();
    }
}