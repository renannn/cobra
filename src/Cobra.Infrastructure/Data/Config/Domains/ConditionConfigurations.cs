using Cobra.Entities.Administration;
using Cobra.Entities.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cobra.Infrastructure.Data.Config.Domains
{
    public class ConditionConfigurations : IEntityTypeConfiguration<Condition>
    {
        public void Configure(EntityTypeBuilder<Condition> builder)
        {
            builder.ToTable("tbl_domains_conditions", "dbo");

            builder.HasMany(x => x.ModelPrices)
                   .WithOne(x => x.Condition)
                   .HasForeignKey(x => x.ConditionId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.ItensBuyList)
                   .WithOne(x => x.Condition)
                   .HasForeignKey(x => x.ConditionId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
