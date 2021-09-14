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
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Condition)
                   .WithMany(x => x.ItensBuyList)
                   .HasForeignKey(x => x.ConditionId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.Images)
                   .WithOne(x => x.BuyListItem)
                   .HasForeignKey(x => x.BuyListItemId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.Messages)
                   .WithOne(x => x.BuyListItem)
                   .HasForeignKey(x => x.BuyListItemId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}