using Application.Abstracts.Repositories;
using Domain.Entities;
using Persistence.Context;


namespace Persistence.Repositories
{
    public class RoleRepository : EfRepositoryBase<Role, Guid, BaseDbContext>, IRoleRepository
    {
        public RoleRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
