//using Domain.Entities;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore.Query;
//using System.Linq.Expressions;

//namespace Application.Abstracts.Services
//{
//    public interface IRoleService
//    {
//        Task<Role?> GetAsync(
//        Expression<Func<Role, bool>> predicate,
//        Func<IQueryable<Role>, IIncludableQueryable<Role, object>>? include = null,
//        bool enableTracking = true);

//        Task<IList<Role>> GetListAsync(
//        Expression<Func<Role, bool>>? predicate = null,
//        Func<IQueryable<Role>, IIncludableQueryable<Role, object>>? include = null,
//        bool enableTracking = true);

//        Task<Role> AddAsync(Role role);

//        Task<Role> UpdateAsync(Role role);

//        Task<Role> DeleteAsync(Role role);

//        //Task<IdentityResult> CreateRoleAsync(string roleName, string description);
//        //Task<IdentityResult> UpdateRoleAsync(Guid roleId, string newName, string newDescription);
//        //Task<IdentityResult> DeleteRoleAsync(Guid roleId);
//        //Task<IdentityRole<Guid>> GetRoleByIdAsync(Guid roleId);
//        //Task<IdentityRole<Guid>> GetRoleByNameAsync(string roleName);
//        //Task<List<IdentityRole<Guid>>> GetAllRolesAsync();
//    }
//}
