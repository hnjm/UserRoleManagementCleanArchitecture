using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserRole : Entity<Guid>
    {
        public Guid RoleId { get; set; }
        public Guid UserId { get; set; }

        public User User { get; set; }
        public Role Role { get; set; }
    }
}
