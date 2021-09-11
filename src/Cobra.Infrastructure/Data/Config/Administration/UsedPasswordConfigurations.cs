using Cobra.Entities.Administration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cobra.Infrastructure.Data.Config.Administration
{
    public class UsedPasswordConfigurations : IEntityTypeConfiguration<UsedPassword>
    {
        public void Configure(EntityTypeBuilder<UsedPassword> builder)
        {
            builder.ToTable("tbl_users_used_passwords", "dbo");

            builder.HasKey("Id")
                   .HasName("id_used_passwords");
        }
    }
}