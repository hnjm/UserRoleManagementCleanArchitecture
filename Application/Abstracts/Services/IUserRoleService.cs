using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Abstracts.Services
{
    public interface IUserRoleService
    {
        Task<UserRole?> GetAsync(
        Expression<Func<UserRole, bool>> predicate,
        Func<IQueryable<UserRole>, IIncludableQueryable<UserRole, object>>? include = null,
        bool enableTracking = true);

        Task<IList<UserRole>> GetListAsync(
        Expression<Func<UserRole, bool>>? predicate = null,
        Func<IQueryable<UserRole>, IIncludableQueryable<UserRole, object>>? include = null,
        bool enableTracking = true);

        Task<UserRole> AddAsync(UserRole userRole);

        Task<UserRole> UpdateAsync(UserRole userRole);

        Task<UserRole> DeleteAsync(UserRole userRole);
    }
}
