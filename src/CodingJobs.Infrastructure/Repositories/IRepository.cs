using System.Linq.Expressions;
using LanguageExt.Common;

namespace CodingJobs.Infrastructure.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    Task<ICollection<TEntity>> GetAllAsync();
    Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity?> UpdateAsync(TEntity entity);
    Task<bool?> RemoveByIdAsync(int id);
}