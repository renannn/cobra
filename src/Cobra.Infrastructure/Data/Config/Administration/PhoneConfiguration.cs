using Cobra.Entities.Administration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cobra.Infrastructure.Data.Config.Administration
{
    public class PhoneConfiguration : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.ToTable("tbl_users_phones", "dbo");

            builder.HasKey("Id")
                   .HasName("id_phone");

            builder.HasOne(x => x.Country)
                .WithMany(x => x.Phones)
                .HasForeignKey(x => x.CountryId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}