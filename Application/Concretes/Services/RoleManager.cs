using Application.Abstracts.Repositories;
using Application.Abstracts.Services;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Concretes.Services
{
    public class RoleManager : IRoleService
    {
        public readonly IRoleRepository _roleRepository;
        // İş kuralı eklenebilir (BusinessRules)

        public RoleManager(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<Role?> GetAsync(Expression<Func<Role, bool>> predicate, Func<IQueryable<Role>, IIncludableQueryable<Role, object>>? include = null, bool enableTracking = true)
        {
            Role? role = await _roleRepository.GetAsync(predicate, include, enableTracking);
            return role;
        }

        public async Task<IList<Role>> GetListAsync(Expression<Func<Role, bool>>? predicate = null, Func<IQueryable<Role>, IIncludableQueryable<Role, object>>? include = null, bool enableTracking = true)
        {
            IList<Role> roleList = await _roleRepository.GetListAsync(predicate, include, enableTracking);
            return roleList;
        }

        public async Task<Role> AddAsync(Role role)
        {
            Role addedRole = await _roleRepository.AddAsync(role);
            return addedRole;
        }

        public async Task<Role> DeleteAsync(Role role)
        {
            Role deletedRole = await _roleRepository.DeleteAsync(role);
            return deletedRole;
        }

        public async Task<Role> UpdateAsync(Role role)
        {
            Role updatedRole = await _roleRepository.UpdateAsync(role);
            return updatedRole;
        }
    }
}
