using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : Entity<Guid>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
