using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Threading;

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
        IQueryable<TEntity> queryable = Context.Set<TEntity>();

        return queryable.FirstOrDefault(predicate);
    }

    public List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate = null)
    {
        IQueryable<TEntity> queryable = Context.Set<TEntity>();

        if (predicate != null)
            queryable = queryable.Where(predicate);

        return queryable.ToList();
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Context.Set<TEntity>();

        if (predicate != null)
            queryable = queryable.Where(predicate);

        return await queryable.ToListAsync();
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        //return await Context.Set<TEntity>().FirstOrDefaultAsync(predicate);

        IQueryable<TEntity> queryable = Context.Set<TEntity>();

        return await queryable.FirstOrDefaultAsync(predicate, cancellationToken);
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