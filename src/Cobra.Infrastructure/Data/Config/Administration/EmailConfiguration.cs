using Cobra.Entities.Administration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cobra.Infrastructure.Data.Config.Administration
{
    public class EmailConfiguration : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            builder.ToTable("tbl_users_emails", "dbo");

            builder.HasKey("Id")
                   .HasName("id_email");

            builder.HasOne(x => x.EmailType)
                   .WithMany(x => x.Emails)
                   .HasForeignKey(x => x.EmailTypeId)
                   .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
