using Cobra.Entities.Administration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cobra.Infrastructure.Data.Config.Domains
{
    public class AddressConfigurations : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("tbl_user_address", "dbo");

            builder.HasOne(x => x.State)
                .WithMany(x => x.Addresses)
                .HasForeignKey(x => x.Sigla);
        }
    }
}
