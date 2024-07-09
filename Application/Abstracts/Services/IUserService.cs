//using Domain.Entities;
//using Microsoft.EntityFrameworkCore.Query;
//using System.Linq.Expressions;

//namespace Application.Abstracts.Services
//{
//    public interface IUserService
//    {
//        Task<User?> GetAsync(
//        Expression<Func<User, bool>> predicate,
//        Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null,
//        bool enableTracking = true);

//        Task<IList<User>> GetListAsync(
//        Expression<Func<User, bool>>? predicate = null,
//        Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null,
//        bool enableTracking = true);

//        Task<User> AddAsync(User user);

//        Task<User> UpdateAsync(User user);

//        Task<User> DeleteAsync(User user);
//    }
//}
