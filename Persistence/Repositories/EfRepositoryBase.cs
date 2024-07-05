using Application.Abstracts.Repositories;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class EfRepositoryBase<TEntity, TEntityId, TContext> : IRepositoryBase<TEntity, TEntityId>
        where TEntity : Entity<TEntityId>
        where TContext : DbContext
    {
        protected readonly TContext Context;

        public EfRepositoryBase(TContext context)
        {
            Context = context;
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool enableTracking = true)
        {
            IQueryable<TEntity> queryable = Context.Set<TEntity>();
            if (!enableTracking)
                queryable = queryable.AsNoTracking();
            if (include != null)
                queryable = include(queryable);
            return await queryable.FirstOrDefaultAsync(predicate);
        }

        public async Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
             bool enableTracking = true)
        {
            IQueryable<TEntity> queryable = Context.Set<TEntity>();
            if (!enableTracking)
                queryable = queryable.AsNoTracking();
            if (include != null)
                queryable = include(queryable);
            if (predicate != null)
                queryable = queryable.Where(predicate);
            return await queryable.ToListAsync();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            await Context.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entities)
        {
            foreach (TEntity item in entities)
                item.CreatedDate = DateTime.UtcNow;
            await Context.AddRangeAsync(entities);
            await Context.SaveChangesAsync();
            return entities;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            entity.UpdatedDate = DateTime.UtcNow;
            Context.Update(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<ICollection<TEntity>> UpdateRangeAsync(ICollection<TEntity> entities)
        {
            foreach (TEntity item in entities)
                item.UpdatedDate = DateTime.UtcNow;
            Context.UpdateRange(entities);
            await Context.SaveChangesAsync();
            return entities;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            entity.DeletedDate = DateTime.UtcNow;
            Context.Remove(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<ICollection<TEntity>> DeleteRangeAsync(ICollection<TEntity> entities)
        {
            foreach (TEntity item in entities)
                item.DeletedDate = DateTime.UtcNow;
            Context.RemoveRange(entities);
            await Context.SaveChangesAsync();
            return entities;
        }
    }
}
