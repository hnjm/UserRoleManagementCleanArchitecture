using Application.Abstracts.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Concretes.Services
{
    public class UserRoleRoleManager
    {
        public readonly IUserRoleRepository _roleRoleRepository;
        // İş kuralı eklenebilir (BusinessRules)

        public UserRoleRoleManager(IUserRoleRepository roleRoleRepository)
        {
            _roleRoleRepository = roleRoleRepository;
        }

        public async Task<UserRole?> GetAsync(Expression<Func<UserRole, bool>> predicate, Func<IQueryable<UserRole>, IIncludableQueryable<UserRole, object>>? include = null, bool enableTracking = true)
        {
            UserRole? role = await _roleRoleRepository.GetAsync(predicate, include, enableTracking);
            return role;
        }

        public async Task<IList<UserRole>> GetListAsync(Expression<Func<UserRole, bool>>? predicate = null, Func<IQueryable<UserRole>, IIncludableQueryable<UserRole, object>>? include = null, bool enableTracking = true)
        {
            IList<UserRole> roleList = await _roleRoleRepository.GetListAsync(predicate, include, enableTracking);
            return roleList;
        }

        public async Task<UserRole> AddAsync(UserRole role)
        {
            UserRole addedUserRole = await _roleRoleRepository.AddAsync(role);
            return addedUserRole;
        }

        public async Task<UserRole> DeleteAsync(UserRole role)
        {
            UserRole deletedUserRole = await _roleRoleRepository.DeleteAsync(role);
            return deletedUserRole;
        }

        public async Task<UserRole> UpdateAsync(UserRole role)
        {
            UserRole updatedUserRole = await _roleRoleRepository.UpdateAsync(role);
            return updatedUserRole;
        }
    }
}
