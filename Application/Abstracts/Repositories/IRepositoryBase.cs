using Domain.Common;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Abstracts.Repositories
{
    public interface IRepositoryBase<TEntity, TEntityId> where TEntity : Entity<TEntityId>
    {
        Task<TEntity?> GetAsync(
            Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool enableTracking = true);

        Task<IList<TEntity>> GetListAsync(
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool enableTracking = true);

        Task<TEntity> AddAsync(TEntity entity);
        Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entities);

        Task<TEntity> UpdateAsync(TEntity entity);
        Task<ICollection<TEntity>> UpdateRangeAsync(ICollection<TEntity> entities);

        Task<TEntity> DeleteAsync(TEntity entity);
        Task<ICollection<TEntity>> DeleteRangeAsync(ICollection<TEntity> entities);
    }
}
