using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.EntityConfigurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles").HasKey(r => r.Id);

            builder.Property(r => r.Id).HasColumnName("Id");
            builder.Property(r => r.Name).HasColumnName("Name");
            builder.Property(r => r.Description).HasColumnName("Description");
        }
    }
}
