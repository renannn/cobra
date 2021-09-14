using Cobra.Entities.Crm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cobra.Infrastructure.Data.Config.CRM
{
    public class ProductWithdrawalConfiguration : IEntityTypeConfiguration<ProductWithdrawal>
    {
        public void Configure(EntityTypeBuilder<ProductWithdrawal> builder)
        {
            builder.ToTable("tbl_buylist_product_withdrawal");

            builder.HasKey("Id").HasName("id_buylist_product_withdrawal");

            builder.HasOne(x => x.BuyList)
                    .WithMany(x => x.ProductsWithdrawal)
                    .HasForeignKey(x => x.BuyListID)
                   .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
