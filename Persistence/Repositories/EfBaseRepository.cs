using Application.Repositories;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Persistence.Repositories.Concrete;

public class EfBaseRepository<TEntity, TId, TContext> : IBaseRepository<TEntity, TId>, IAsyncBaseRepository<TEntity, TId>
    where TEntity : BaseEntity<TId>, new()
    where TContext : DbContext
{
    protected readonly TContext Context;

    public EfBaseRepository(TContext context)
    {
        Context = context;
    }

    public TEntity Add(TEntity entity)
    {
        entity.CreatedDate = DateTime.Now;
        Context.Add(entity);
        Context.SaveChanges();
        return entity;
    }

    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        entity.CreatedDate = DateTime.Now;
        await Context.AddAsync(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public TEntity Delete(TEntity entity)
    {
        entity.DeletedDate = DateTime.Now;
        // Hard Delete - Soft Delete
        // Context.Remove(entity); // Hard Delete
        Context.Update(entity);
        Context.SaveChanges();
        return entity;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        entity.DeletedDate = DateTime.Now;
        Context.Update(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public TEntity? Get(Expression<Func<TEntity, bool>> predicate)
    {
        return Context.Set<TEntity>().FirstOrDefault(predicate);
    }

    public List<TEntity> GetAll()
    {
        return Context.Set<TEntity>().ToList();
    }

    public async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await Context.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await Context.Set<TEntity>().FirstOrDefaultAsync(predicate);
    }

    public TEntity? GetById(TId id)
    {
        return Context.Set<TEntity>()
            .AsNoTracking()
            .FirstOrDefault(entity => entity.Id.Equals(id) && !entity.DeletedDate.HasValue);
    }

    public async Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken = default)
    {
        return await Context.Set<TEntity>()
            .AsNoTracking()
            .FirstOrDefaultAsync(entity => entity.Id.Equals(id) && !entity.DeletedDate.HasValue);
    }

    public TEntity Update(TEntity entity)
    {
        entity.UpdatedDate = DateTime.Now;
        Context.Update(entity);
        Context.SaveChanges();
        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        entity.UpdatedDate = DateTime.Now;
        Context.Update(entity);
        await Context.SaveChangesAsync();
        return entity;
    }
}