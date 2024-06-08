using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users").HasKey(u => u.Id);

            builder.Property(u => u.Id).HasColumnName("Id").IsRequired();
            builder.Property(u => u.UserName).HasColumnName("Username").IsRequired();
            builder.Property(u => u.Password).HasColumnName("Password").IsRequired();
        }
    }
}
