using Application.Abstracts.Repositories;
using Domain.Entities;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class UserRoleRepository : EfRepositoryBase<UserRole, Guid, BaseDbContext>, IUserRoleRepository
    {
        public UserRoleRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
