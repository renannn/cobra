using Cobra.Entities.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cobra.Infrastructure.Data.Config.Images
{

    public class InspectionItemImageConfigurations : IEntityTypeConfiguration<InspectionItemImage>
    {
        public void Configure(EntityTypeBuilder<InspectionItemImage> builder)
        {
            builder.ToTable("tbl_images_inspections_itens_images", "dbo");

            builder.HasOne(x => x.InspectionItem)
                   .WithMany(x => x.Images)
                   .HasForeignKey(x => x.InspectionItemId);
        }
    }
}
