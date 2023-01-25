using System.Linq.Expressions;
using CodingJobs.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace CodingJobs.Infrastructure.Repositories.Skill;

public class SkillRepository : ISkillRepository
{
    private readonly ApplicationDbContext _context;

    public SkillRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<ICollection<Domain.Models.Skill>> GetAllAsync()
    {
        return await _context.Skills.AsNoTracking().ToListAsync();
    }

    public async Task<Domain.Models.Skill?> FindAsync(Expression<Func<Domain.Models.Skill, bool>> predicate)
    {
        return await _context.Skills.FirstOrDefaultAsync(predicate);
    }

    public Task<Domain.Models.Skill> AddAsync(Domain.Models.Skill entity)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Models.Skill?> UpdateAsync(Domain.Models.Skill entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}