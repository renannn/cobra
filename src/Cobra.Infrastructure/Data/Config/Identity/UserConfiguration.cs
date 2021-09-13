using Cobra.Entities.Administration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cobra.Infrastructure.Data.Config.Identity
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("tbl_users", "dbo");

            builder.HasKey("Id")
                   .HasName("id_user");

            builder.HasMany(x => x.Phones)
                   .WithOne(x => x.User)
                   .HasForeignKey(x => x.UserId);

            builder.HasMany(x => x.Emails)
                   .WithOne(x => x.User)
                   .HasForeignKey(x => x.UserId);

            builder.HasMany(x => x.BuyLists)
                   .WithOne(x => x.User)
                   .HasForeignKey(x => x.UserId);

            builder.HasMany(x => x.Addresses)
                   .WithOne(x => x.User)
                   .HasForeignKey(x => x.UserId);

            builder.HasMany(x => x.PaymentMethods)
                   .WithOne(x => x.User)
                   .HasForeignKey(x => x.UserId);

            builder.HasMany(x => x.UserUsedPasswords)
                   .WithOne(x => x.User)
                   .HasForeignKey(x => x.UserId);

            builder.HasMany(x => x.Logins)
                   .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);

            builder.HasMany(x => x.Payments)
                   .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
        }
    }
}
