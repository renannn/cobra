using Cobra.Entities.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cobra.Infrastructure.Data.Config.Images
{
    public class BuyListItemImageConfigurations : IEntityTypeConfiguration<BuyListItemImage>
    {
        public void Configure(EntityTypeBuilder<BuyListItemImage> builder)
        {
            builder.ToTable("tbl_images_buyLists_itens", "dbo");
        }
    }
}
