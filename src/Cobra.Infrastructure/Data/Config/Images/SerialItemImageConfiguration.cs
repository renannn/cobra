using Cobra.Entities.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cobra.Infrastructure.Data.Config.Images
{
    public class SerialItemImageConfiguration : IEntityTypeConfiguration<SerialItemImage>
    {
        public void Configure(EntityTypeBuilder<SerialItemImage> builder)
        {
            builder.ToTable("tbl_images_product_withdrawal_serials", "dbo");

            builder.HasOne(x => x.SerialItem)
                   .WithMany(x => x.Images)
                   .HasForeignKey(x => x.SerialItemId);
        }
    }
}
