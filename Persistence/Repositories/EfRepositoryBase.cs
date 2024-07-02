
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
        public Task<TEntity> AddAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<TEntity>> DeleteRangeAsync(ICollection<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            throw new NotImplementedException();
        }

        public Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<TEntity>> UpdateRangeAsync(ICollection<TEntity> entities)
        {
            throw new NotImplementedException();
        }
    }
}
