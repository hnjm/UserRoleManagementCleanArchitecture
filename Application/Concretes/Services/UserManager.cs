using Application.Abstracts.Repositories;
using Application.Abstracts.Services;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Concretes.Services
{
    public class UserManager : IUserService
    {
        public readonly IUserRepository _userRepository;
        // İş kuralı eklenebilir (BusinessRules)

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> GetAsync(Expression<Func<User, bool>> predicate, Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null, bool enableTracking = true)
        {
            User? user = await _userRepository.GetAsync(predicate, include, enableTracking);
            return user;
        }

        public async Task<IList<User>> GetListAsync(Expression<Func<User, bool>>? predicate = null, Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null, bool enableTracking = true)
        {
            IList<User> userList=await _userRepository.GetListAsync(predicate, include, enableTracking);
            return userList;
        }

        public async Task<User> AddAsync(User user)
        {
            User addedUser =await _userRepository.AddAsync(user);
            return addedUser;
        }

        public async Task<User> DeleteAsync(User user)
        {
            User deletedUser=await _userRepository.DeleteAsync(user);
            return deletedUser;
        }

        public async Task<User> UpdateAsync(User user)
        {
            User updatedUser=await _userRepository.UpdateAsync(user);
            return updatedUser;
        }
    }
}
