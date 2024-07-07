using Application.Abstracts.Repositories;
using Application.Abstracts.Services;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Concretes.Services
{
    public class UserRoleManager : IUserRoleService
    {
        public readonly IUserRoleRepository _userRoleRepository;
        // İş kuralı eklenebilir (BusinessRules)

        public UserRoleManager(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public async Task<UserRole?> GetAsync(Expression<Func<UserRole, bool>> predicate, Func<IQueryable<UserRole>, IIncludableQueryable<UserRole, object>>? include = null, bool enableTracking = true)
        {
            UserRole? role = await _userRoleRepository.GetAsync(predicate, include, enableTracking);
            return role;
        }

        public async Task<IList<UserRole>> GetListAsync(Expression<Func<UserRole, bool>>? predicate = null, Func<IQueryable<UserRole>, IIncludableQueryable<UserRole, object>>? include = null, bool enableTracking = true)
        {
            IList<UserRole> roleList = await _userRoleRepository.GetListAsync(predicate, include, enableTracking);
            return roleList;
        }

        public async Task<UserRole> AddAsync(UserRole role)
        {
            UserRole addedUserRole = await _userRoleRepository.AddAsync(role);
            return addedUserRole;
        }

        public async Task<UserRole> DeleteAsync(UserRole role)
        {
            UserRole deletedUserRole = await _userRoleRepository.DeleteAsync(role);
            return deletedUserRole;
        }

        public async Task<UserRole> UpdateAsync(UserRole role)
        {
            UserRole updatedUserRole = await _userRoleRepository.UpdateAsync(role);
            return updatedUserRole;
        }
    }
}
