using Cobra.Entities.Administration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cobra.Infrastructure.Data.Config.Identity
{
    public class UserClaimConfiguration : IEntityTypeConfiguration<UserClaim>
    {
        public void Configure(EntityTypeBuilder<UserClaim> builder)
        {
            builder.ToTable("tbl_users_clains", "dbo");

            builder.HasKey("Id")
                   .HasName("id_user_claim");

            builder.HasOne(x => x.User)
                   .WithMany(x => x.Claims)
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
