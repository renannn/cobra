using Cobra.Entities.Crm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cobra.Infrastructure.Data.Config.CRM
{
    public class BuyListItemConfigurations : IEntityTypeConfiguration<BuyListItem>
    {
        public void Configure(EntityTypeBuilder<BuyListItem> builder)
        {
            builder.ToTable("tbl_users_buylists_itens", "dbo");

            builder.HasOne(x => x.Model)
                   .WithMany(x => x.ItensBuyList)
                   .HasForeignKey(x => x.ModelId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Condition)
                   .WithMany(x => x.ItensBuyList)
                   .HasForeignKey(x => x.ConditionId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Images)
                   .WithOne(x => x.BuyListItem)
                   .HasForeignKey(x => x.BuyListItemId);

            builder.HasMany(x => x.Messages)
                   .WithOne(x => x.BuyListItem)
                   .HasForeignKey(x => x.BuyListItemId);
        }
    }
}