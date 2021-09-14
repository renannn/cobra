using Cobra.Entities.Crm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cobra.Infrastructure.Data.Config.CRM
{
    public class ProductWithdrawalItemConfiguration : IEntityTypeConfiguration<ProductWithdrawalItem>
    {
        public void Configure(EntityTypeBuilder<ProductWithdrawalItem> builder)
        {
            builder.ToTable("tbl_buylist_product_withdrawal_item");

            builder.HasKey("Id").HasName("id_buylist_product_withdrawal_item");

            builder.HasOne(x => x.ProductWithdrawal)
                    .WithMany(x => x.Itens)
                    .HasForeignKey(x => x.ProductWithdrawalId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.BuyListItem)
                    .WithMany(x => x.ProductWithdrawalItens)
                    .HasForeignKey(x => x.BuyListItemId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
