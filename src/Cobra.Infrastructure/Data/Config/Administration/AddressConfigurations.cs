using Cobra.Entities.Administration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cobra.Infrastructure.Data.Config.Administration
{
    public class AddressConfigurations : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("tbl_users_addresses", "dbo");

            builder.HasKey("Id")
                   .HasName("id_address");

            builder.HasOne(x => x.City)
                .WithMany(x => x.Addresses)
                .HasForeignKey(x => x.CityId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}