using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Abstracts.Services
{
    public interface IRoleService
    {
        Task<Role?> GetAsync(
        Expression<Func<Role, bool>> predicate,
        Func<IQueryable<Role>, IIncludableQueryable<Role, object>>? include = null,
        bool enableTracking = true);

        Task<IList<Role>> GetListAsync(
        Expression<Func<Role, bool>>? predicate = null,
        Func<IQueryable<Role>, IIncludableQueryable<Role, object>>? include = null,
        bool enableTracking = true);

        Task<Role> AddAsync(Role role);

        Task<Role> UpdateAsync(Role role);

        Task<Role> DeleteAsync(Role role);
    }
}
