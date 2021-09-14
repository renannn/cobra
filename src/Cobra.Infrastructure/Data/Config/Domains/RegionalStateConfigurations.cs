using Cobra.Entities.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cobra.Infrastructure.Data.Config.Domains
{
    public class RegionalStateConfigurations : IEntityTypeConfiguration<RegionalState>
    {
        public void Configure(EntityTypeBuilder<RegionalState> builder)
        {
            builder.ToTable("tbl_domains_regional_state", "dbo");

            builder.HasKey("Id");

            builder.HasMany(x => x.Cities)
                .WithOne(x => x.State)
                .HasForeignKey(x => x.Sigla);
        }
    }
}
