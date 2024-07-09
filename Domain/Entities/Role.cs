using Domain.Common;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class Role : IdentityRole<Guid>   //Entity<Guid>
    {              
        public string Description { get; set; }      
    }
}
