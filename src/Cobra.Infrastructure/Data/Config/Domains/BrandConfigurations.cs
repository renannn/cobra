using Cobra.Entities.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cobra.Infrastructure.Data.Config.Domains
{
    public class BrandConfigurations : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("tbl_domains_brands", "dbo");

            builder.HasKey("Id");

            builder.HasMany(x => x.Images)
                    .WithOne(x => x.Brand)
                    .HasForeignKey(x => x.BrandId);
        }
    }
}
