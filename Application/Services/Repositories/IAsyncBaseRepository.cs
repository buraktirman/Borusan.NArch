using Domain.Entities;
using System.Linq.Expressions;

namespace Application.Services.Repositories;

public interface IAsyncBaseRepository<TEntity, TId>
       where TEntity : BaseEntity<TId>, new()
{
    // GetAllAsync GetAsync vs..
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken = default);
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);

}
