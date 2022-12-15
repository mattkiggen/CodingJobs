using System.Linq.Expressions;

namespace CodingJobs.Infrastructure.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    Task<ICollection<TEntity>> GetAllAsync();
    Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate);
    Task AddAsync(TEntity entity);
    Task RemoveAsync(TEntity entity);
}