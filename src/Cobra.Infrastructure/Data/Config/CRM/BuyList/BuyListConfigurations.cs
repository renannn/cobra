using Cobra.Entities.Crm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cobra.Infrastructure.Data.Config.CRM
{
    public class BuyListConfigurations : IEntityTypeConfiguration<BuyList>
    {
        public void Configure(EntityTypeBuilder<BuyList> builder)
        {
            builder.ToTable("tbl_users_buylists", "dbo");


            builder.HasMany(x => x.BuyListItens)
                   .WithOne(x => x.BuyList)
                   .HasForeignKey(x => x.BuyListId);

            builder.HasMany(x => x.Inspections)
                   .WithOne(x => x.BuyList)
                   .HasForeignKey(x => x.BuyListId);

            builder.HasMany(x => x.Messages)
                   .WithOne(x => x.BuyList)
                   .HasForeignKey(x => x.BuyListId);

        }
    }
}