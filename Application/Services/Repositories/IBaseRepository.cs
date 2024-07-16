using Domain.Entities;
using System.Linq.Expressions;

namespace Application.Services.Repositories;

public partial interface IBaseRepository<TEntity, TId>
    where TEntity : BaseEntity<TId>, new()
{
    TEntity Add(TEntity entity);
    TEntity Delete(TEntity entity);
    TEntity Update(TEntity entity);
    TEntity? GetById(TId id);
    TEntity? Get(Expression<Func<TEntity, bool>> predicate);
    List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null);
}
