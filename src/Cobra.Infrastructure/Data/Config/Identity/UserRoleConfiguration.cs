using Cobra.Entities.Administration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cobra.Infrastructure.Data.Config.Identity
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("tbl_users_roles", "dbo");

            builder.Property(t => t.RoleId)
                .HasColumnName("role_id");

            builder.Property(t => t.UserId)
                .HasColumnName("user_id");

            builder.HasOne(x => x.Role)
              .WithMany(x => x.Users)
              .HasForeignKey(x => x.RoleId);

            builder.HasOne(x => x.User)
                .WithMany(x => x.Roles)
                .HasForeignKey(x => x.UserId);

            builder.HasIndex(p => new { p.UserId, p.RoleId })
               .HasDatabaseName("cst_user_role_unique")
               .IsUnique();
        }
    }
}
