using Cobra.Entities.Crm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cobra.Infrastructure.Data.Config.CRM
{
    public class SerialItemConfiguration : IEntityTypeConfiguration<SerialItem>
    {
        public void Configure(EntityTypeBuilder<SerialItem> builder)
        {
            builder.ToTable("tbl_buylist_product_withdrawal_item_serial");

            builder.HasIndex("Id").HasDatabaseName("id_buylist_product_withdrawal_item_serial");

            builder.HasOne(x => x.ProductWithdrawalItem)
                    .WithMany(x => x.Serials)
                    .HasForeignKey(x => x.ProductWithdrawalItemId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
